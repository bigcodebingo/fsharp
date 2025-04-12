let rec isPrime n i =
    match n with
    | _ when n <= 2 -> n = 2
    | _ when n % i = 0 -> false
    | _ when i * i > n -> true
    | _ -> isPrime n (i + 1)

let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)

// Метод 1: Максимальный простой делитель
let maxPrimeDivisor n =
    let rec findMaxDivisor n divisor maxPrime =
        match divisor > n with
        | true -> maxPrime
        | false ->
            match n % divisor = 0 && isPrime divisor 2 with
            | true -> findMaxDivisor n (divisor + 1) divisor
            | false -> findMaxDivisor n (divisor + 1) maxPrime
    
    match n < 2 with
    | true -> None
    | false ->
        let result = findMaxDivisor n 2 0
        match result = 0 with
        | true -> None
        | false -> Some result

// Метод 2: Произведение цифр, не делящихся на 5
let productOfDigitsNotDivBy5 n =
    let rec product n acc =
        match n with
        | 0 -> acc
        | _ ->
            let digit = n % 10
            let newAcc = 
                match digit % 5 <> 0 with
                | true -> acc * digit
                | false -> acc
            product (n / 10) newAcc
    
    match n = 0 with
    | true -> 1
    | false -> product (abs n) 1

// Метод 3: НОД максимального нечетного непростого делителя и произведения цифр
let method3 n =
    let rec getAllDivisors n i acc =
        match i > n with
        | true -> acc
        | false ->
            match n % i = 0 with
            | true -> getAllDivisors n (i + 1) (i::acc)
            | false -> getAllDivisors n (i + 1) acc
    
    let divisors = getAllDivisors (abs n) 1 [] |> List.rev

    let rec findMaxOddNonPrime divisors currentMax =
        match divisors with
        | [] -> currentMax
        | head::tail ->
            match head % 2 <> 0 && not (isPrime head 2) with
            | true -> findMaxOddNonPrime tail (max head currentMax)
            | false -> findMaxOddNonPrime tail currentMax
    
    let maxOddNonPrime = findMaxOddNonPrime divisors 1
    let product = productOfDigitsNotDivBy5 n
    gcd maxOddNonPrime product


let getFunction = function
    | 1 -> fun n -> maxPrimeDivisor n |> sprintf "%A"
    | 2 -> fun n -> productOfDigitsNotDivBy5 n |> sprintf "%d"
    | 3 -> fun n -> method3 n |> sprintf "%d"
    | _ -> fun _ -> "Неверный номер функции"


let main = 
    (fun (funcNum, arg) -> getFunction funcNum arg) >> printfn "Результат: %s"

main (1, 45)   
main (2, 12345) 
main (3, 45)   
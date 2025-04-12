//задание 13-14 работа со взаимно простыми числами
let rec gcd a b = 
     match b with
     | 0 -> a
     | _ -> gcd b (a % b)
 
let traverseCoprimes number operation initial =
     let rec loop current acc =
         match current <= 1 with
         | true -> acc
         | false ->
             let isCoprime = gcd current number = 1
             let newAcc = 
                 match isCoprime with
                 | true -> operation acc current
                 | false -> acc
             loop (current - 1) newAcc
     loop number initial
 
let eulerPhi n = 
     traverseCoprimes n (fun acc _ -> acc + 1) 0

let testCoprimes () =
    printfn "Сумма взаимно простых с 10: %d" (traverseCoprimes 10 (+) 0)
    printfn "fi(10) = %d" (eulerPhi 10)

//задание 15 работа со взаимно простыми числами с условиями
let traverseCoprimesWithCond number operation initial cond =
    let rec loop current acc =
        match current <= 1 with
        | true -> acc
        | false ->
            let isCoprime = gcd current number = 1
            let meetsCond = cond current
            let newAcc = 
                match isCoprime && meetsCond with
                 | true -> operation acc current
                 | false -> acc
            loop (current - 1) newAcc
    loop number initial

let sumEvenCoprimes n =
    traverseCoprimesWithCond n (+) 0 (fun x -> x % 2 = 0)

let testCondCoprimes () =
     printfn "Сумма чётных взаимно простых с 10: %d" (sumEvenCoprimes 10)

testCoprimes()
testCondCoprimes()

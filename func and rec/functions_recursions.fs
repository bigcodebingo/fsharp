let rec sumOfDigits n =
    if n = 0 then 
        0
    else 
        (n%10) + sumOfDigits (n/10)

printf "введите число:"
let number = System.Console.ReadLine() |> int

let sum = sumOfDigits number
printf "сумма цифр %d равна %d" number sum
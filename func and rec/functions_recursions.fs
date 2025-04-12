let sumOfDigits n =
    let rec sumCifr n curSum = 
        if n = 0 then curSum
        else
            let n1 = n/10
            let cifr = n%10
            let newSum = curSum + cifr
            sumCifr n1 newSum
    sumCifr n 0

let main () = 
    let sum = sumOfDigits 333
    printfn "Сумма цифр числа 333: %d" sum

main()
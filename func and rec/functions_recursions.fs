let circleSquare r =
    let pi = 3.14159
    pi * r * r

let cylindreVolume r h =
    h * circleSquare r

let main() =
    //суперпозиция
    printf "введите радиус круга:"
    let radius = System.Console.ReadLine() |> float
    printfn "введите высоту цилиндра:"
    let height = System.Console.ReadLine() |> float
    let start = circleSquare >> ((*) height)
    let res = start radius

    printf "объем цилинда (суперпозиция): %f" res
    
    //каррирование
    printf "\nвведите радиус круга:"
    let radius2 = System.Console.ReadLine() |> float
    printfn "введите высоту цилиндра:"
    let height2 = System.Console.ReadLine() |> float
    let start2 = cylindreVolume radius2
    let res2 = start2 height2

    printf "объем цилинда (каррирование): %f" res2

main()
let sum_of_digits n =
     n
     |> abs
     |> string
     |> Seq.map (fun ch -> int ch - int '0')
     |> Seq.sum
 
let count_divisors n =
     let n = abs n
     [1 .. n] |> List.filter (fun x -> n % x = 0) |> List.length
 
let sort_b list =
     list
     |> List.sortBy (fun x -> (sum_of_digits x, -abs x))
 
let sort_c list =
     list
     |> List.sortByDescending (fun x -> (count_divisors x, abs x))
 
let make_triples a b c =
     let sortedA = List.sortDescending a
     let sortedB = sort_b b
     let sortedC = sort_c c
     List.zip3 sortedA sortedB sortedC

let main =  
    let a = [3; 1; 5]
    let b = [22; 4; 11]  
    let c = [10; 5; 6]   
 
    let result = make_triples a b c
 
    printfn "Результат:"
    result |> List.iter (fun (x, y, z) -> printfn "(%d, %d, %d)" x y z)

main
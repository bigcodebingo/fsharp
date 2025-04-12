let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
     match list with
     | [] -> acc
     | head::tail ->
         let current = head
         let newAcc = if condition current then f acc current else acc
         reduce_list tail f condition newAcc


let main = 
    let sumEven = reduce_list [1;2;3;4;5;6] (+) (fun x -> x % 2 = 0) 0
    System.Console.WriteLine("Сумма четных: {0}", sumEven)

main
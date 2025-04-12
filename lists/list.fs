let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
     match list with
     | [] -> acc
     | head::tail ->
         let current = head
         let newAcc = if condition current then f acc current else acc
         reduce_list tail f condition newAcc

let min_list list = 
     match list with
     | [] -> 0
     | head::tail -> reduce_list list (fun a b -> if a < b then a else b) (fun a -> true) head
 
let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0
 
let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0

let main = 
    System.Console.Write("Минимум в списке: ")
    System.Console.WriteLine(min_list [1;2;3;4;5;6])
 
    System.Console.Write("Сумма четных в списке: ")
    System.Console.WriteLine(sum_even [1;2;3;4;5;6])
 
    System.Console.Write("Количество нечетных в списке: ")
    System.Console.WriteLine(count_odd [1;2;3;4;5;6])

main
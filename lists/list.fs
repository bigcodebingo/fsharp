let rec frequency list num count =
     match list with
     | [] -> count
     | head :: tail ->
         let newCount = if head = num then count + 1 else count
         frequency tail num newCount
 
let rec freq_list list main_list cur_list =
     match list with
     | [] -> cur_list
     | head :: tail ->
         let freq_elem = frequency main_list head 0
         let new_list = cur_list @ [freq_elem]
         freq_list tail main_list new_list

let pos list el =
     let rec pos_inner list el num =
         match list with
         | [] -> 0
         | head :: tail ->
             if head = el then num
             else pos_inner tail el (num + 1)
     pos_inner list el 1

let get_from_list list pos =
     let rec get list num cur_num =
         match list with
         | [] -> 0
         | head :: tail ->
             if num = cur_num then head
             else get tail num (cur_num + 1)
     get list pos 1
 
let max_list list =
     let rec find_max lst current_max =
         match lst with
         | [] -> current_max
         | head :: tail ->
             let new_max = if head > current_max then head else current_max
             find_max tail new_max
     match list with
     | [] -> 0
     | head :: tail -> find_max tail head
 
let find_most_frequent list =
     let fL = freq_list list list []
     let maxFreq = max_list fL
     let index = pos fL maxFreq
     get_from_list list index



let main = 
    System.Console.Write("Самый частый элемент: ")
    System.Console.WriteLine(find_most_frequent [5; 3; 8; 1; 4; 6; 5; 3; 5])

main
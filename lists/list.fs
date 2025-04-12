// вывести индексы списка в порядке убывания элементов
let solve_1_4_list lst =
     lst
     |> List.mapi (fun i v -> (i, v))           
     |> List.sortByDescending snd               
     |> List.map fst  

// найти кол-во элементов в интервале 
let solve_1_14_list (a: int) (b: int) (lst: int list) : int =
     lst
     |> List.filter (fun x -> x >= a && x <= b)
     |> List.length

let solve_1_14 a b lst =
    
    let rec filterInRange acc lst =
        match lst with
        | [] -> acc
        | head :: tail ->
            if head >= a && head <= b then
                filterInRange (head :: acc) tail
            else
                filterInRange acc tail

    let rec countElements lst count =
        match lst with
        | [] -> count
        | _ :: tail -> countElements tail (count + 1)

    let filteredList = filterInRange [] lst
    countElements filteredList 0

// найти 2 наибольших элемента
let solve_1_24_list (lst: int list) : (int * int) =
     let sorted = lst |> List.sortDescending
     match sorted with
     | x :: y :: _ -> (x, y)
     | _ -> failwith "мало элементов"

let rec solve_1_24 lst =
    match lst with
    | [] -> []
    | head :: tail ->
        let smallerSorted = solve_1_24 tail
        let rec insert x sortedList =
            match sortedList with
            | [] -> [x]  
            | h :: t when x >= h -> x :: sortedList  
            | h :: t -> h :: (insert x t)  
        insert head smallerSorted

// найти элементы в отрезке
let solve_1_34_list (a: int) (b: int) (lst: int list) : int list =
     lst |> List.filter (fun x -> x >= a && x <= b)

let solve_1_34 a b lst =
    
    let rec filterInRange acc lst =
        match lst with
        | [] -> acc
        | head :: tail ->
            if head >= a && head <= b then
                filterInRange (head :: acc) tail
            else
                filterInRange acc tail

    filterInRange [] lst

// чередуются ли в массиве int float
let solve_1_44 (lst: float list) : bool =
    let rec checkHelper lst prevIsInt =
        match lst with
        | [] -> true  
        | head :: tail ->
            let isCurrentInt = head = float (int head)
            if isCurrentInt = prevIsInt then
                false  
            else
                checkHelper tail isCurrentInt  
    match lst with
    | [] -> true  
    | head :: tail ->
        let isFirstInt = head = float (int head)
        checkHelper tail isFirstInt

// построить список из элементов встречающихся более 3 раз
let solve_1_54_list (lst: int list) : int list =
     lst
     |> List.countBy id                  
     |> List.filter (fun (_, count) -> count > 3)
     |> List.map fst

let main =
    printfn "1.4: %A" (solve_1_4_list [3; 1; 4; 2])
    printfn "1.14: %A" (solve_1_14_list 2 5 [3; 1; 4; 2])
    printfn "1.24: %A" (solve_1_24_list [3; 1; 4; 2])
    printfn "1.34: %A" (solve_1_34_list 2 5 [3; 1; 4; 2])
    printfn "1.54: %A" (solve_1_54_list [1;1;1;1;2;2;2;3;3;3;3;3])

    printfn "1.14 без List: %A" (solve_1_14 2 5 [3; 1; 4; 2])
    let sorted = solve_1_24 [3; 1; 4; 2]
    printfn "1.24 без List: %A" (solve_1_24_list sorted)
    printfn "1.34 без List: %A" (solve_1_34 2 5 [3; 1; 4; 2])
    printfn "1.44 без List: %b" (solve_1_44 [1.0; 2.5; 3.0; 4.5; 5.0])

main
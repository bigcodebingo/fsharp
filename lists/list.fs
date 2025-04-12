type BinaryTree =
     | Empty
     | Node of string * BinaryTree * BinaryTree
 
let rec insert tree value =
     match tree with
     | Empty -> Node(value, Empty, Empty)
     | Node(v, left, right) ->
         if value < v then Node(v, insert left value, right)
         else Node(v, left, insert right value)
 
let rec inOrder tree =
     match tree with
     | Empty -> []
     | Node(value, left, right) ->
         inOrder left @ [value] @ inOrder right
 
let testTree =
     Empty
     |> fun t -> insert t "mango"
     |> fun t -> insert t "apple"
     |> fun t -> insert t "peach"
     |> fun t -> insert t "banana"



let main = 
    System.Console.WriteLine("\nСодержимое строки в двоичном дереве (in-order):")
    inOrder testTree |> List.iter (printfn "%s")

main
let sort_strings_by_length (lst: string list) : string list =
     lst |> List.sortBy String.length
 
 
let readStringList n =
     let rec read acc n =
         match n with
         | 0 -> acc
         | _ ->
             let line = System.Console.ReadLine()
             read (acc @ [line]) (n - 1)
     read [] n


let main =
     System.Console.Write("Введите количество строк: ")
     let n = System.Console.ReadLine() |> int
     System.Console.WriteLine("Введите строки:")
     let stringList = readStringList n
 
     let sorted = sort_strings_by_length stringList
 
     System.Console.WriteLine("\nОтсортированные строки по длине:")
     sorted |> List.iter (printfn "%s")
 
main
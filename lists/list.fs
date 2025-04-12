let count_squares list =
     list
     |> List.filter (fun x -> List.exists (fun y -> y * y = x) list)
     |> List.length


let main =  
    let test = [5; 3; 8; 4; 6; 5; 3; 5; 2]
    System.Console.Write("Количество квадратов в списке: ")
    System.Console.WriteLine(count_squares test)

main
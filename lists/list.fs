let find_most_frequent_list_based list =
     list
     |> List.countBy id         
     |> List.maxBy snd          
     |> fst 


let main = 
    let test = [5; 3; 8; 1; 4; 6; 5; 3; 5]
    System.Console.Write("Самый частый элемент: ")
    System.Console.WriteLine(find_most_frequent_list_based test)

main
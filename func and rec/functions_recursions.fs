//задание 11
let reactToLanguage language =
     match language with
     | "F#" | "Prolog" -> "Ты — подлиза!"
     | "Python" -> "Банально"
     | "Java" -> "ооп..."
     | "C++" -> "1 курс)"
     | _ -> "Хороший вкус!"

//задание 12
let mainSuperposition () =
     let readInput () = System.Console.ReadLine()
     let processInput = readInput >> reactToLanguage
     printfn "Введите ваш любимый язык:"
     processInput () |> printfn "%s"
 
let mainCurrying () =
     let readAndReact reactFunc =
         printfn "Введите ваш любимый язык:"
         System.Console.ReadLine() |> reactFunc |> printfn "%s"
     readAndReact reactToLanguage


printf "%s" (reactToLanguage "Java")
mainSuperposition() 
mainCurrying()
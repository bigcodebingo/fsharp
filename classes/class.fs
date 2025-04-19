open System

type Message =
    | PrintMessage of string    
    | DoubleNumber of int       
    | Stop                      

let agent = MailboxProcessor.Start(fun inbox ->
    let rec loop () =
        async {
            let! msg = inbox.Receive()

            match msg with
            | PrintMessage text ->
                printfn "Получено сообщение: %s" text
                return! loop ()

            | DoubleNumber num ->
                printfn "Число удвоено: %d" (num * 2)
                return! loop ()

            | Stop ->
                printfn "Агент завершает работу."
                return ()
        }
    loop ()
)

agent.Post(PrintMessage "Hello, world!")  
agent.Post(DoubleNumber 5)                 
agent.Post(DoubleNumber 10)               
agent.Post(Stop)                          

Console.ReadLine() |> ignore

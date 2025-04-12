let rec readList n = 
    if n=0 then 
        []
    else
        let Head = System.Convert.ToInt32(System.Console.ReadLine())
        let Tail = readList (n-1)
        Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  


[<EntryPoint>]
let main argv = 
    let l = readData
    writeList l
open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

let maybeToString (maybe: Maybe<'a>) =
    match maybe with
    | Just x -> sprintf "Just %A" x
    | Nothing -> "Nothing"

let returned x = Just x

let apply f maybe =
    match f, maybe with
    | Just f, Just x -> Just (f x)
    | _ -> Nothing

let id x = x + 1

let law1 value =
    let left = apply (returned id) (returned value)
    let right = id value
    if left = returned right then
        printfn "pass" 
    else
        printfn "fail" 

let law2 f x =
    let left = apply (returned f) (returned x)
    let right = returned (f x)
    if left = right then
        printfn "pass" 
    else
        printfn "fail"

let f1 x = x + 10

law1 (5)
law2 f1 5   







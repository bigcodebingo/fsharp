open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

let maybeToString (maybe: Maybe<'a>) =
    match maybe with
    | Just x -> sprintf "Just %A" x
    | Nothing -> "Nothing"

let bind maybe f =
    match maybe with
    | Just x -> f x
    | Nothing -> Nothing

let test1 = bind (Just 5) (fun x -> Just (x * 2))
let test2 = bind Nothing (fun x -> Just (x * 2))

Console.WriteLine(maybeToString test1)
Console.WriteLine(maybeToString test2)






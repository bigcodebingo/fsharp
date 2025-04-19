open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

let maybeToString (maybe: Maybe<'a>) =
    match maybe with
    | Just x -> sprintf "Just %A" x
    | Nothing -> "Nothing"

let fmapMaybe f maybe =
    match maybe with
    | Just x -> Just (f x)
    | Nothing -> Nothing

let law2 value f g =
    let left = fmapMaybe (f >> g) value
    let right = value |> fmapMaybe f |> fmapMaybe g
    if left = right then
        printfn "passed"
    else
        printfn "fail"

let increment x = x + 1
let double x = x * 2

let test1 = fmapMaybe increment (Just 5)
let test2 = fmapMaybe increment Nothing
law2 (Just 5) increment double 

Console.WriteLine(maybeToString test1)
Console.WriteLine(maybeToString test2)
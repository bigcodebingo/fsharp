open System

let normal_line x y =
    y / (4.0 * x)

let reflect fallingM n =
    (2.0 * n - fallingM + fallingM * n ** 2.0) / (2.0 * fallingM * n - n ** 2.0 + 1.0)

let findC m x y =
    y - m * x

let resolveQuad a b c =
    let d = b*b - 4.0*a*c
    let sqrtD = Math.Sqrt(d)
    [(-b + sqrtD) / (2.0 * a); (-b - sqrtD) / (2.0 * a)]

let nextPoint m c x_old =
    resolveQuad (4.0 + m*m) (2.0 * m * c) (c*c - 100.0)
    |> List.find (fun x_new -> abs (x_old - x_new) >= 1e-10)
    |> fun x_new -> (x_new, m * x_new + c)

let rec countReflections point fallingM count =
    let x, y = point
    match abs x <= 0.01 && y > 0.0 with
    | true -> count
    | false ->
        let n = normal_line x y
        let m3 = reflect fallingM n
        let c = findC m3 x y
        let pNext = nextPoint m3 c x
        countReflections pNext m3 (count + 1)

let initialPoint = (1.4, -9.6)
let firstSlope = -19.7 / 1.4

let totalCount = countReflections initialPoint firstSlope 0

printfn "количество отражений: %d" totalCount

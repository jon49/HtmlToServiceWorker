module Test

open FParsec

let test p str ``default`` =
    match run p str with
    | Success(result, _, _)   ->
        (result, "")
    | Failure(errorMsg, _, _) ->
        (``default``, errorMsg)

//let pfloat = pfloat

let str s = pstring s
let floatBetweenBrackets : Parser<float, unit> = str "[[" >>. pfloat .>> str "]]"


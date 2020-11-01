module HtmlParser

open FParsec
open ParsedTypes

let test p str ``default`` =
    match run p str with
    | Success(result, _, _)   ->
        (result, "")
    | Failure(errorMsg, _, _) ->
        (``default``, errorMsg)

let str s = pstring s
let ws = spaces
let betweenStrings s1 s2 p = between (str s1) (str s2) p
let betweenSpaces parser = (ws >>. parser .>> ws)

let slot : Parser<HtmlType, unit> =
    identifier (IdentifierOptions())
    |> betweenSpaces
    |> betweenStrings "{{" "}}"
    |>> fun x -> Slot { Name = x }




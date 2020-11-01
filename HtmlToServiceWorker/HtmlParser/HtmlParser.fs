module HtmlParser

open FParsec

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
let slotIdentifier c = isLetter c || c = '-'
let slot : Parser<string, unit> =
    //many1Satisfy2L isLetter slotIdentifier "Slot Identifier"
    identifier (IdentifierOptions())
    |> betweenSpaces
    |> betweenStrings "{{" "}}"
    |>> fun x -> $"""["{x}"],"""




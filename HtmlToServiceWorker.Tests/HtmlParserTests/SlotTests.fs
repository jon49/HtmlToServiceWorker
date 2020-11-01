namespace HtmlToServiceWorker.Tests.HtmlParserTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open ParsedTypes

[<TestClass>]
type SlotTests () =

    [<DataTestMethod>]
    [<DataRow("{{Yes}}")>]
    [<DataRow("{{  Yes  }}")>]
    [<DataRow("{{Yes  }}")>]
    [<DataRow("{{  Yes}}")>]
    [<DataRow("{{\nYes}}")>]
    member _.``Should get name of slot`` (value : string) =
        let (result, errorMessage) = HtmlParser.test HtmlParser.slot value ( Slot { Name = "Unknown" } )
        Assert.AreEqual("""Slot { Name = "Yes" }""", sprintf "%A" result, errorMessage)

    [<TestMethod>]
    member _.``Should fail when incorrect data`` () =
        let (result, errorMessage) = HtmlParser.test HtmlParser.slot "No" ( Slot { Name = "Failed" } )
        Assert.IsTrue(errorMessage.Contains("Expecting: '{{'"))


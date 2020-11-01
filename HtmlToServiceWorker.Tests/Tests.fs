namespace HtmlToServiceWorker.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<DataTestMethod>]
    [<DataRow("{{Yes}}")>]
    [<DataRow("{{  Yes  }}")>]
    [<DataRow("{{Yes  }}")>]
    [<DataRow("{{  Yes}}")>]
    [<DataRow("{{\nYes}}")>]
    member _.``Should get name of slot`` (value : string) =
        let (result, errorMessage) = HtmlParser.test HtmlParser.slot value "Unknown"
        Assert.AreEqual("""["Yes"],""", result, errorMessage)


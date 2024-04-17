namespace Tests

open Occurrences.Program
open NUnit.Framework
open System
open System.IO

    [<TestFixture>]

    type Tests() =

    [<Test>]

    member this.countTest() = // 
        let testFile : string = "Application.fs"
        let testFileContent : string = """
               Application
               Application.fs
               Application
               
               text
               AppLiCation
               
               othertext
               Application.fs
               Application
               sometext""" 
        //let testFileContent = [ |"application"; "Application.fs"; "Application"; "text"; "AppLiCation";
        //                         ""; "othertext"; "Application.fs"; "Application" ""; "sometext"]

        let testResult = Program.count testFileContent (Path.GetFileNameWithoutExtension testFile)

        Assert.AreEqual(5, testResult)
        
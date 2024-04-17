namespace Tests

open NUnit
open NUnit.Framework

open Occurrences.Program
open System
open System.IO

[<TestFixture>]
type Tests() =

    [<Test>]
    member this.counterTest() =

        // Specifying directory for test-files
        let directoryPath = "/home/lucas/prog/task/files/"

        // Collect all test-files in 'files'
        let files = Directory.GetFiles(directoryPath)

        // Iterate over each file
        for filePath in files do

            let testResult = count filePath (Path.GetFileNameWithoutExtension filePath)

            // Set to 3 for brevity. All files in 'files' have an occurrence of 3 with their own name
            let expectedResult = 3

            // Asserting equality between the expected result and test result
            Assert.That(expectedResult, Is.EqualTo(testResult))
    //[<Test>]
    //member this.emptyFileTest() =
      //  let filepath = /home/lucas/prog/task/EmptyFile.whatever
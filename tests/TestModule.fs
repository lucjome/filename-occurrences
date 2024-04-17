namespace Tests

open NUnit
open NUnit.Framework
open Occurrences.Program
open System
open System.IO

[<TestFixture>]
type Tests() =

    // Test counter works properly
    [<Test>]
    member this.TestCount() =
        // Specifying directory for test files
        let directoryPath: string = "/home/lucas/prog/filename-occurrences/files/"

        Directory.GetFiles(directoryPath) 
        |> Array.iter (fun filePath -> // Iterating over testfiles in 'files'

            let testResult: int = count filePath (Path.GetFileNameWithoutExtension filePath)
            let expectedResult: int = 3 // Set to 3 for brevity. All files have occurrence 3

            Assert.That(expectedResult, Is.EqualTo(testResult)))


    // Test for count returning 0 with empty file
    [<Test>]
    member this.TestCountEmptyFile() =
        // Path to an empty file
        let filePath: string = "/home/lucas/prog/filename-occurrences/EmptyFile.whatever"

        let testResult: int = count filePath (Path.GetFileNameWithoutExtension filePath) 

        // Expected result for an empty file
        let expectedResult: int = 0

        // Assert equality between the expected result and test result
        Assert.That(expectedResult, Is.EqualTo(testResult))
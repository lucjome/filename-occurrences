namespace AltCounters
    open System
    open System.IO

    module AlternativeCounters =
        let count2 (fileName :string) (fileNameWOExtension :string) : int =
            try
                let file = File.OpenText fileName // Accessing the file

                Seq.initInfinite (fun _ -> file.ReadLine()) // Returns <string seq> of file
                    |> Seq.takeWhile (fun line ->  line <> null) // take until end of sequence
                    |> Seq.filter (fun line -> line.Contains fileNameWOExtension) // Filters lines with filename
                    |> Seq.length // Finally, yielding the count of names
                
                
            with
                
            | :? System.IO.FileNotFoundException ->
                failwithf "Error: File not found - %s" fileName
            | :? System.ArgumentException ->
                failwithf "Error: Invalid filename - %s" fileName
            | :? System.UnauthorizedAccessException ->
                failwithf "Error: Access to file %s is unauthorized." fileName
            | ex ->
                failwithf "An unexpected error occurred: %s" ex.Message

                
        let count3 (fileName : string) (fileNameWOExtension : string): int =
            let mutable counter = 0

            try
                use file = File.OpenText fileName
                while not file.EndOfStream do   // Read entire file
                    let line = file.ReadLine()
                    if line.Contains fileNameWOExtension then
                        counter <- counter + 1 
                counter
            with
                
            | :? System.IO.FileNotFoundException ->
                failwithf "Error: File not found - %s" fileName
            | :? System.ArgumentException ->
                failwithf "Error: Invalid filename - %s" fileName
            | :? System.UnauthorizedAccessException ->
                failwithf "Error: Access to file %s is unauthorized." fileName
            | ex ->
                failwithf "An unexpected error occurred: %s" ex.Message
        


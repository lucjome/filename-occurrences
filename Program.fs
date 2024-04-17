
namespace Occurrences
    open System
    open System.IO


    module Program =
           
        let count (fileName :string) (fileNameWOExtension :string) : int =
            try
                let lines = File.ReadAllLines fileName // Read all lines from the file into a sequence

                lines
                |> Seq.filter (fun line -> line.Contains fileNameWOExtension) // Filter lines containing the file name without extension
                |> Seq.length // Finally, yield the count of matching lines
                
            with
                
            | :? System.IO.FileNotFoundException ->
                failwithf "Error: File not found - %s" fileName
            | :? System.ArgumentException ->
                failwithf "Error: Invalid filename - %s" fileName
            | :? System.UnauthorizedAccessException ->
                failwithf "Error: Access to file %s is unauthorized." fileName
            | (ex: exn) ->
                failwithf "An unexpected error occurred: %s" ex.Message


        let run (args : string[]) : unit =
            match args with 
                | [| fileName |] ->        // Pattern match on 1-element array
                    let fileNameWOExtension = Path.GetFileNameWithoutExtension fileName 
                    let occurrences = count fileName fileNameWOExtension // yield number of occurrences
                    
                    printf "The number of occurences of %s is %d" fileNameWOExtension occurrences
                    
                | _ ->
                    printfn "Please provide exactly 1 argument" 
                    Environment.Exit(1)

        [<EntryPoint>]
        let main argv =
            run argv
            0

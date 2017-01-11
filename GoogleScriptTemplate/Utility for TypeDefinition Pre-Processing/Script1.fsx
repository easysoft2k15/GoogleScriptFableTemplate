open System.IO
Directory.GetFiles( __SOURCE_DIRECTORY__ + "\\typeDefinition","*.fs")
|> Array.iter (fun f -> printfn "%s" f)


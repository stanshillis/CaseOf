// include Fake libs
#r "FAKE.4.9.0/tools/FakeLib.dll"

open Fake

let buildToolsDir = @"./build-tools/"
let buildDir = @"./build/"
let packageDir = @"./package/"
let version = "1.0.0"

Target "Clean" (fun _ -> 
    CleanDirs [packageDir; buildDir]
)

Target "Compile" (fun _ ->
    MSBuildRelease buildDir "Build" (!! "CaseOf.sln")
    |> Log "Build output: "
)

Target "CreatePackage" (fun _ ->
    let accessKey = getBuildParamOrDefault "accessKey" ""
    NuGet (fun p -> 
        {p with
            Authors = ["Stan Shillis"]
            Project = "CaseOf"
            Description = "Micro library inspired by F# single case discriminated unions. Create primitive domain concepts in C# with one line."
            OutputPath = packageDir
            Summary = "Micro library inspired by F# single case discriminated unions. Create primitive domain concepts in C# with one line."
            WorkingDir = buildDir
            Version = version
            Files = [(@"*.*", Some "lib", None);
                     (@"../README.md", Some "", None)]
            AccessKey = accessKey
            Publish = match accessKey with
                      | "" -> false
                      | _ -> true  })
            (buildToolsDir + "CaseOf.nuspec")

)

"Clean" ==> "Compile" ==> "CreatePackage"

RunTargetOrDefault "CreatePackage"
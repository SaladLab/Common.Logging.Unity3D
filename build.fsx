#I @"packages/FAKE/tools"
#I @"packages/FAKE.BuildLib/lib/net451"
#r "FakeLib.dll"
#r "BuildLib.dll"

open Fake
open BuildLib

let solution = 
    initSolution
        "./Common.Logging.Unity3D.sln" "Release" 
        [ ]


Target "Clean" <| fun _ -> cleanBin 

Target "Restore" <| fun _ -> restoreNugetPackages solution

Target "Build" <| fun _ -> buildSolution solution

Target "Package" <| fun _ -> buildUnityPackage "./src/UnityPackage"

Target "Help" <| fun _ -> 
    showUsage solution (fun name -> 
        if name = "package" then Some("Build package", "")
        else None)

"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "Package"

RunTargetOrDefault "Help"

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

Target "PackUnity" <| fun _ ->
    packUnityPackage "./src/UnityPackage/CommonLogging.unitypackage.json"

Target "Pack" <| fun _ -> ()

Target "CI" <| fun _ -> ()

Target "Help" <| fun _ ->
    showUsage solution (fun _ -> None)

"Clean"
  ==> "Restore"
  ==> "Build"

"Build" ==> "PackUnity"
"PackUnity" ==> "Pack"

"Pack" ==> "CI"

RunTargetOrDefault "Help"

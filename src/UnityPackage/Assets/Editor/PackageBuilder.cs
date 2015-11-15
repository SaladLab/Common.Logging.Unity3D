using UnityEditor;

public static class PackageBuilder
{
    [MenuItem("Assets/Build UnityPackage")]
    public static void BuildPackage()
    {
        var assetPaths = new string[]
        {
            "Assets/Middleware/CommonLogging",
            "Assets/Middleware/CommonLoggingSample",
        };

        var packagePath = "Common-Logging-Unity3D.unitypackage";
        var options = ExportPackageOptions.Recurse;
        AssetDatabase.ExportPackage(assetPaths, packagePath, options);
    }
}

#if UNITY_EDITOR
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public static class PlistEditScript
{
    [PostProcessBuild]
    static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.iOS)
        {
            return;
        }
        string unityAppControllerPath = pathToBuiltProject + "/Info.plist";
        if (File.Exists(unityAppControllerPath))
        {
            string unityAppController = File.ReadAllText(unityAppControllerPath);
            Match match = Regex.Match(unityAppController, @"<key>CFBundleIdentifier</key>");
            if (match.Success)
            {
                string newCode = match.Groups[0].Value.Remove(match.Groups[0].Value.Length - 1);
                newCode = "<key>FirebaseScreenReportingEnabled</key>\n<false/>\n<key>CFBundleIdentifier</key>";
                unityAppController = unityAppController.Replace(match.Groups[0].Value, newCode);
            }
            File.WriteAllText(unityAppControllerPath, unityAppController);
        }

        Debug.Log("--------srcpath:"+Application.dataPath + "/Plugins/iOS/GoogleService-Info.plist");
        Debug.Log("target path :------------" + pathToBuiltProject + "/GoogleService-Info.plist");
        File.Copy(Application.dataPath + "/Plugins/iOS/GoogleService-Info.plist", pathToBuiltProject + "/GoogleService-Info.plist");
        
    }
}
#endif
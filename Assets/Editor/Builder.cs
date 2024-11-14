using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Builder
{
    public static void Build()
    {
        // Define scenes to build
        string[] scenes = { "Assets/MineSweeper/Scenes/MainMenu.unity", "Assets/MineSweeper/Scenes/MainGame.unity" };

        // Specify the output path and platform
        var report = BuildPipeline.BuildPlayer(scenes, "Builds/MazeyRun.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);


        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build successful - Build written");
        }
        else if (report.summary.result == BuildResult.Failed)
        {
            Debug.LogError($"Build failed");
        }
    }
}

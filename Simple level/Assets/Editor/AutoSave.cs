using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaveEditor
{
    private const float SaveInterval = 120f; // Save interval in seconds
    private static double nextSaveTime;

    static AutoSaveEditor()
    {
        nextSaveTime = EditorApplication.timeSinceStartup + SaveInterval;
        EditorApplication.update += Update;
    }

    private static void Update()
    {
        if (EditorApplication.timeSinceStartup >= nextSaveTime)
        {
            SaveProject();
            nextSaveTime = EditorApplication.timeSinceStartup + SaveInterval;
        }
    }

    private static void SaveProject()
    {
        Debug.Log("Auto-saving project...");
        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
    }
}


using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ImageBackground;

[BepInPlugin("goi.ext.imagebackground", "Background Image", "0.1.0")]
public class ImageBackground : BaseUnityPlugin
{
    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo("Background Image is loaded!");
    }
}

using System.IO;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ImageBackground;

[BepInPlugin("goi.ext.imagebackground", "Background Image", "1.0.0")]
public class ImageBackground : BaseUnityPlugin
{
    private ConfigEntry<string> imagePath;

    private void Awake()
    {
        string defaultPath = Application.dataPath + "/../Backgrounds/";
        if (!Directory.Exists(defaultPath))
            Directory.CreateDirectory(defaultPath);

        imagePath = Config.Bind(
            "",
            "Path to Background Image",
            defaultPath + "Image.png",
            "The location of the image for use as the background in your system"
        );

        Logger.LogInfo("Background Image is loaded!");
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Mian") {
            SetupBackground();
        }
    }

    private void SetupBackground() {
        Transform parent = GameObject.Find("Main Camera/BGCamera").transform;
        Transform canvas = new GameObject("Canvas", typeof(Canvas)).transform;
        canvas.SetParent(parent);
        canvas.gameObject.layer = 11; // Set to sky layer

        RectTransform background = new GameObject("Background", typeof(Image)).GetComponent<RectTransform>();
        background.SetParent(canvas);
        background.anchorMax = Vector2.one;
        background.anchorMin = Vector2.zero;
        background.offsetMax = Vector2.zero;
        background.offsetMin = Vector2.zero;
        background.localPosition = new Vector3(0f, 0f, 2769f);
        background.sizeDelta = new Vector2(Screen.width, Screen.height);

        Image backgroundImage = background.GetComponent<Image>();
        backgroundImage.sprite = LoadImageToSprite();
    }

    private Sprite LoadImageToSprite() {
        Texture2D tex = new Texture2D(2, 2);
        byte[] imageBytes = File.ReadAllBytes(imagePath.Value);

        ImageConversion.LoadImage(tex, imageBytes);

        return Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }
}

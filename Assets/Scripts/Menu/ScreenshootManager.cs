using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenshootManager : MonoBehaviour
{
    public GameObject canvasUI;
    public Canvas canvasWatermark;
    public bool isTakeScereenshot = true;

    private void Update()
    {
        AmbilFoto();
    }

    private IEnumerator Screenshoot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string fileName = "MyHome-" + System.DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".png";
#if UNITY_STANDALONE_WIN
        // PC
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../" + fileName, bytes);
#elif UNITY_ANDROID
        // Android
        NativeGallery.SaveImageToGallery(texture, "MyHome Screenshot", fileName);
#endif

        Destroy(texture);
        canvasUI.SetActive(true);
        canvasWatermark.enabled = false;
    }

    public void TakeScreenshoot()
    {
        canvasUI.SetActive(false);
        canvasWatermark.enabled = true;
        StartCoroutine("Screenshoot");
        Debug.Log("Screenshot Berhasil...");
    }

    public void AmbilFoto()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            TakeScreenshoot();
        }
    }
}
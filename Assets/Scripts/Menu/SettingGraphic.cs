using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingGraphic : MonoBehaviour
{
    public GameObject textFullscreen, toggleFullscreen;

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        textFullscreen.SetActive(true);
        toggleFullscreen.SetActive(true);
#elif UNITY_ANDROID
        textFullscreen.SetActive(false);
        toggleFullscreen.SetActive(false);
#endif
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void SetFullscreen(bool isFullscreen)
    {
#if UNITY_STANDALONE_WIN
        Screen.fullScreen = isFullscreen;
#endif
    }

}

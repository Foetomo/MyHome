using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingGraphic : MonoBehaviour
{
    public GameObject textFullscreen, toggleFullscreen, resolusi;

    [SerializeField]
    private TMP_Dropdown resolusiDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filterResolutions;
    private float currentRefreshRate;
    private int currentResolusiIndex = 12;

    private void Awake()
    {

    }

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        textFullscreen.SetActive(true);
        toggleFullscreen.SetActive(true);
        resolusi.SetActive(true);
        Resolutions();
#elif UNITY_ANDROID
        textFullscreen.SetActive(false);
        toggleFullscreen.SetActive(false);
        resolusi.SetActive(false);
#endif
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    void Resolutions()
    {
#if UNITY_STANDALONE_WIN
        resolutions = Screen.resolutions;
        filterResolutions = new List<Resolution>();

        resolusiDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        Debug.Log("RefreshRate: " + currentRefreshRate);

        for (int i = 0; i < resolutions.Length; i++)
        {
            Debug.Log("Resolution: " + resolutions[i]);
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filterResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filterResolutions.Count; i++)
        {
            string resolusiOption = filterResolutions[i].width + " X " + filterResolutions[i].height + " " + filterResolutions[i].refreshRate + " Hz";
            options.Add(resolusiOption);

            if (filterResolutions[i].width == Screen.width && filterResolutions[i].height == Screen.height)
            {
                currentResolusiIndex = i;
            }
        }

        resolusiDropdown.AddOptions(options);
        resolusiDropdown.value = currentResolusiIndex;
        resolusiDropdown.RefreshShownValue();
#endif
    }

    public void SetResolution(int resolusiIndex)
    {
        Resolution resolution = filterResolutions[resolusiIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void SetFullscreen(bool isFullscreen)
    {
#if UNITY_STANDALONE_WIN
        Screen.fullScreen = isFullscreen;
#endif
    }

}

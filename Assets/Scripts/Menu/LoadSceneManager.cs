using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider, _controlSlider;
    public GameObject muteMusicOn, muteMusicOff, muteSfxOn, muteSfxOff;
    private float valueMusic = 1f;
    private float valueSfx = 1f;
    private float valueControl = 5f;
    public static int muteM;

    public GameObject menu, mulai, panelOpsi, panelExit, panelHitam;
    public Animator animationPanelOpsi, animationPanelExit;
    bool isClose = false;

    private void Awake()
    {
        valueMusic = PlayerPrefs.GetFloat("VolumeMusic", valueMusic);
        valueSfx = PlayerPrefs.GetFloat("VolumeSfx", valueSfx);
        valueControl = PlayerPrefs.GetFloat("Control", valueControl);

        _sfxSlider.value = valueSfx;
        _musicSlider.value = valueMusic;
        _controlSlider.value = valueControl;
    }

    private void Start()
    {
        muteM = PlayerPrefs.GetInt("muteMusic", 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isClose = !isClose;
            if (isClose)
            {
                animationPanelExit.Play("Buka");
                panelHitam.SetActive(true);
            }
            else
            {
                animationPanelExit.Play("Tutup");
                panelHitam.SetActive(false);
            }
        }

        muteMusicOn.SetActive(true);

        if (muteM == 0)
        {
            muteMusicOn.SetActive(false);
            muteMusicOff.SetActive(true);
        }

        if (muteM == 1)
        {
            muteMusicOn.SetActive(true);
            muteMusicOff.SetActive(false);
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();

        if (AudioManager.Instance.musicSource.mute)
        {
            muteM = 0;
            PlayerPrefs.SetInt("muteMusic", muteM);
        }
        else if (!AudioManager.Instance.musicSource.mute)
        {
            muteM = 1;
            PlayerPrefs.SetInt("muteMusic", muteM);
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        PlayerPrefs.SetFloat("VolumeMusic", _musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        PlayerPrefs.SetFloat("VolumeSfx", _sfxSlider.value);
    }

    public void ControlSetting()
    {
        //Movement.Instance.SettingSensitivy(_controlSlider.value);
        //movement.SettingSensitivy(_controlSlider.value);
        ControlSensitivity.Instance.SettingSensitivy(_controlSlider.value);
        PlayerPrefs.SetFloat("Control", _controlSlider.value);
    }

    public void ButtonMulai()
    {
        menu.SetActive(false);
        mulai.SetActive(true);
    }

    public void ButtonCloseMulai()
    {
        menu.SetActive(true);
        mulai.SetActive(false);
    }

    public void ButtonExit()
    {
        //panelExit.SetActive(true);
        animationPanelExit.Play("Buka");
        panelHitam.SetActive(true);
    }

    public void ButtonCloseExit()
    {
        //panelExit.SetActive(false);
        animationPanelExit.Play("Tutup");
        panelHitam.SetActive(false);
    }

    public void ButtonOpsi()
    {
        //panelOpsi.SetActive(true);
        animationPanelOpsi.Play("Buka");
        panelHitam.SetActive(true);
    }

    public void ButtonCloseOpsi()
    {
        //panelOpsi.SetActive(false);
        animationPanelOpsi.Play("Tutup");
        panelHitam.SetActive(false);
    }

    public void ButtonTentang()
    {

    }

    public void ButtonCloseTentang()
    {

    }

    // Pindah Scene menggunakan String
    public void LoadScene(string namescene)
    {
        Debug.Log("Berhasil Pindah Scene " + namescene);
        SceneManager.LoadScene(namescene);
    }

    public void LoadScene(int index)
    {
        Debug.Log("Berhasil Pindah Scene " + index);
        SceneManager.LoadScene(index);
    }

    // Keluar Aplikasi
    public void Quit()
    {
        Debug.Log("Berhasil Keluar");
        Application.Quit();
    }
}

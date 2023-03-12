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
    public static int muteM, muteS, indexOpsi;

    public GameObject menu, mulai, panelOpsi, panelExit, panelHitam;
    public Animator animationPanelOpsi, animationPanelExit, animationPanelTentang;
    bool isClose = false;

    private void Awake()
    {
        muteM = PlayerPrefs.GetInt("muteMusic", 0);
        muteS = PlayerPrefs.GetInt("muteSFX", 0);
        valueMusic = PlayerPrefs.GetFloat("VolumeMusic", valueMusic);
        valueSfx = PlayerPrefs.GetFloat("VolumeSfx", valueSfx);
        valueControl = PlayerPrefs.GetFloat("Control", valueControl);
        indexOpsi = PlayerPrefs.GetInt("saveOpsi", 0);
    }

    private void Start()
    {
        _sfxSlider.value = valueSfx;
        _musicSlider.value = valueMusic;
        _controlSlider.value = valueControl;

        CursorLook();
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
        muteSfxOn.SetActive(true);

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

        if (muteS == 0)
        {
            muteSfxOn.SetActive(false);
            muteSfxOff.SetActive(true);
        }

        if (muteS == 1)
        {
            muteSfxOn.SetActive(true);
            muteSfxOff.SetActive(false);
        }

        if (indexOpsi == 0)
        {
            //ButtonCloseOpsi();
        }
        
        if (indexOpsi == 1)
        {
            ButtonOpsi();
        }
    }

    void CursorLook()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void ToggleMusic()
    {
        KlikSFX.Instance.Klik();
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
        KlikSFX.Instance.Klik();
        AudioManager.Instance.ToggleSFX();
        if (AudioManager.Instance.sfxSource.mute)
        {
            muteS = 0;
            PlayerPrefs.SetInt("muteSFX", muteS);
        }
        else if (!AudioManager.Instance.sfxSource.mute)
        {
            muteS = 1;
            PlayerPrefs.SetInt("muteSFX", muteS);
        }
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
        KlikSFX.Instance.Klik();
        menu.SetActive(false);
        mulai.SetActive(true);
    }

    public void ButtonCloseMulai()
    {
        KlikSFX.Instance.Klik();
        menu.SetActive(true);
        mulai.SetActive(false);
    }

    public void ButtonExit()
    {
        KlikSFX.Instance.Klik();
        //panelExit.SetActive(true);
        animationPanelExit.Play("Buka");
        panelHitam.SetActive(true);
    }

    public void ButtonCloseExit()
    {
        KlikSFX.Instance.Klik();
        //panelExit.SetActive(false);
        animationPanelExit.Play("Tutup");
        panelHitam.SetActive(false);
    }

    public void ButtonOpsi()
    {
        indexOpsi = 1;
        animationPanelOpsi.Play("Buka");
        panelHitam.SetActive(true);
        PlayerPrefs.SetInt("saveOpsi", indexOpsi);
    }

    public void ButtonCloseOpsi()
    {
        indexOpsi = 0;
        animationPanelOpsi.Play("Tutup");
        panelHitam.SetActive(false);
        PlayerPrefs.SetInt("saveOpsi", indexOpsi);
    }

    public void ButtonTentang()
    {
        KlikSFX.Instance.Klik();
        animationPanelTentang.Play("Buka");
        panelHitam.SetActive(true);
    }

    public void ButtonCloseTentang()
    {
        KlikSFX.Instance.Klik();
        animationPanelTentang.Play("Tutup");
        panelHitam.SetActive(false);
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

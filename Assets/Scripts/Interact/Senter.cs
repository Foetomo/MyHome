using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senter : MonoBehaviour
{
    public GameObject senterObjek;
    bool isAktif = false;

    private void Start()
    {

    }

    void Update()
    {
        NyalaSenter();
    }

    public void NyalaSenter()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isAktif = !isAktif;
            if (isAktif)
            {
                senterObjek.SetActive(true);
                AudioManager.Instance.PlaySFX("FlashlightOn");
            }
            else
            {
                senterObjek.SetActive(false);
                AudioManager.Instance.PlaySFX("FlashlightOff");
            }
        }
    }

    public void Flashlight()
    {
        isAktif = !isAktif;
        if (isAktif)
        {
            senterObjek.SetActive(true);
            AudioManager.Instance.PlaySFX("FlashlightOn");
        }
        else
        {
            senterObjek.SetActive(false);
            AudioManager.Instance.PlaySFX("FlashlightOff");
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chair : MonoBehaviour, Interactable
{
    public GameObject player, playerDuduk;
    public GameObject canvasAndroid, backgroundText, interactImage, rotateText, infoText, buttonQ;
    public GameObject bgImageTxt;
    public TextMeshProUGUI closeText;
    public string key = "KELUARSIT";
    public bool isSitting;
    bool berdiri = true;
    bool interact;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSitting = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSitting = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Berdiri();
    }

    private void LateUpdate()
    {
        
    }

    public void Sitting()
    {
        if (isSitting == true)
        {
            player.SetActive(false);
            playerDuduk.SetActive(true);
            canvasAndroid.SetActive(false);
            backgroundText.SetActive(false);
            interactImage.SetActive(false);
            rotateText.SetActive(false);
            infoText.SetActive(true);
#if UNITY_ANDROID
            buttonQ.SetActive(true);
#endif
            bgImageTxt.SetActive(true);
            closeText.text = GameMultiLang.GetTraduction(key);
            berdiri = true;
            isSitting = false;
        }  
    }


    public void Berdiri()
    {
        if (berdiri == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.SetActive(true);
                playerDuduk.SetActive(false);
                backgroundText.SetActive(true);
                interactImage.SetActive(true);
                rotateText.SetActive(true);
                infoText.SetActive(false);
                bgImageTxt.SetActive(false);
                berdiri = false;
            }
        }
    }

    public void BerdiriAndroid()
    {
        if (berdiri == true)
        {
            player.SetActive(true);
            playerDuduk.SetActive(false);
            canvasAndroid.SetActive(true);
            backgroundText.SetActive(true);
            interactImage.SetActive(true);
            rotateText.SetActive(true);
            infoText.SetActive(false);
            buttonQ.SetActive(false);
            bgImageTxt.SetActive(false);
            berdiri = false;
        }
    }

    public void Interact()
    {
        Sitting();
    }
}

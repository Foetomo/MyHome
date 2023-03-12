using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tentang : MonoBehaviour
{
    public GameObject panelTentang, buttonSelectedTentang;
    public GameObject panelKredit, buttonSelectedKredit;
    public TextMeshProUGUI teksTentang;
    string tentang = "TENTANG";
    string kredit = "KREDIT";

    private void Update()
    {

    }

    public void TentangButton()
    {
        if (panelTentang == true)
        {
            KlikSFX.Instance.Klik();
            panelTentang.SetActive(true);
            panelKredit.SetActive(false);
            buttonSelectedTentang.SetActive(true);
            buttonSelectedKredit.SetActive(false);
            teksTentang.text = GameMultiLang.GetTraduction(tentang);
        }
    }    
    public void KreditButton()
    {
        if (panelKredit == true)
        {
            KlikSFX.Instance.Klik();
            panelTentang.SetActive(false);
            panelKredit.SetActive(true);
            buttonSelectedTentang.SetActive(false);
            buttonSelectedKredit.SetActive(true);
            teksTentang.text = GameMultiLang.GetTraduction(kredit);
        }
    }
}

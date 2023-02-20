using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMProGraphicDropDown : MonoBehaviour
{
    [SerializeField] string[] graphic;
    TMP_Dropdown drp;
    int index;

    private void Awake()
    {
        drp = this.GetComponent<TMP_Dropdown>();
        int g = PlayerPrefs.GetInt("graphic", 2);
        drp.value = g;

        drp.onValueChanged.AddListener(delegate {
            index = drp.value;
            PlayerPrefs.SetInt("graphic", index);
            PlayerPrefs.SetString("graphicText", graphic[index]);
            //apply changes
        });
    }

}

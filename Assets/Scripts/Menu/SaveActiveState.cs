using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveActiveState : MonoBehaviour
{
    private GameObject objek;
    private string key;

    // Start is called before the first frame update
    void Start()
    {
        objek = this.gameObject;
        key = gameObject.name + "_active";

        if (PlayerPrefs.HasKey(key))
        {
            bool isActive = (PlayerPrefs.GetInt(key) == 1);
            gameObject.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        int value = (gameObject.activeSelf) ? 1 : 0;
        PlayerPrefs.SetInt(key, value);
    }
}

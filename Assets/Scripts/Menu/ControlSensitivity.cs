using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSensitivity : MonoBehaviour
{
    public static ControlSensitivity Instance;

    [Range(1, 5)]
    public float sensitivity = 5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sensitivity = GetComponent<Movement>().sensitivty;
    }

    public void SettingSensitivy(float range)
    {
        sensitivity = range;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlikSFX : MonoBehaviour
{
    public static KlikSFX Instance;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {

    }

    public void Klik()
    {
        AudioManager.Instance.PlaySFX("Klik");
    }
}

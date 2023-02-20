using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public FixedButton rotateKanan, rotateKiri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var r = GetComponent<ObjectPickup>();

        r.rotatingKanan = rotateKanan.pressed;
        r.rotatingKiri = rotateKiri.pressed;
    }
}

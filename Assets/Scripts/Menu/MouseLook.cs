using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static MouseLook Instance;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}

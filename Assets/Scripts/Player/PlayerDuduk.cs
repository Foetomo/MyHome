using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuduk : MonoBehaviour
{
    public ControllerMode controllerMode;
    public float minVerticalLook;
    public float maxVerticalLook;
    [Range(1, 5)]
    public float sensitivty;
    public float smoothLook;
    [Range(0, 1)]
    public float screenTouchForCamera;
    public Transform CameraHolder;
    private Vector2 Look;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputed();
        ControlSensitivity cs = FindObjectOfType<ControlSensitivity>();
        sensitivty = cs.sensitivity;
    }

    private void LateUpdate()
    {
        Looking();
    }

    void Inputed()
    {
        switch (controllerMode)
        {
//#if UNITY_STANDALONE_WIN
            case ControllerMode.PC:
                Look.x += Input.GetAxis("Mouse X") * sensitivty * smoothLook * Time.timeScale;
                Look.y -= Input.GetAxis("Mouse Y") * sensitivty * smoothLook * Time.timeScale;
                break;
//#elif UNITY_ANDROID
            case ControllerMode.Android:
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    if (InputManager.instance.verifiedTouch(touch, Screen.width * screenTouchForCamera))
                    {
                        switch (touch.phase)
                        {
                            case TouchPhase.Moved:
                                Look.x += touch.deltaPosition.x * sensitivty * Time.deltaTime;
                                Look.y -= touch.deltaPosition.y * sensitivty * Time.deltaTime;
                                break;
                        }
                    }
                }
                break;
//#endif
        }
    }

    private void Looking()
    {
        Look.y = Mathf.Clamp(Look.y, minVerticalLook, maxVerticalLook); //membatasi melihat secara vertikal
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Look.x, transform.eulerAngles.z); //mengrotasikan bagian y (y = horizontal bagian rotasi) 
        CameraHolder.localEulerAngles = new Vector3(Look.y, CameraHolder.localEulerAngles.y, CameraHolder.localEulerAngles.z); //mengrotasikan bagian y (x = vertical bagian rotasi) 
    }
}

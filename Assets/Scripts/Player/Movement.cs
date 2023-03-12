using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public static Movement Instance;
    public ControllerMode controllerMode;
    public GameObject canvasAndroid;
    
    //jika ingin menggunakan PC controller harus dicabut remote Androidnya
    //jika ingin menggunakan Android controller harus menggunakan screen simulator 

    [Header("Steering")]
    public float gravity;
    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;

    public enum MoveMode {
        Walk, Run, Crouch
    }
    public MoveMode moveMode;

    public float crouchHeight;
    public float normalHeight;
    public float weightCrouch;
    public LayerMask crouchLayer;

    [Header("Camera")]
    public float minVerticalLook;
    public float maxVerticalLook;
    [Range(1, 5)]
    public float sensitivty;
    public float smoothLook;
    public Transform CameraHolder;

    [Header("Mobile Controller")] 
    [Range(0, 1)]
    public float screenTouchForCamera;
    private bool mobileCrouch, mobileRun; //For mobile only

    [Header("Animator")]
    //public Animator animator;

    private CharacterController charcc;
    private Vector2 Move, Look;
    private bool isRunning, isCrouching;

    Vector2 currentLookDelta = Vector2.zero;
    Vector2 currentLookVelocity = Vector2.zero;

    private float currentWeightCrouch, speed, requirementMoveZRun;

    private FootstepSystem fs;
    private float walk_step_distance = 0.4f;

    private void Start () {
        charcc = GetComponent<CharacterController>();
        fs = GetComponent<FootstepSystem>();

        fs.step_Distance = walk_step_distance;
        //control = GetComponent<ControlSensitivity>();

        
        if(controllerMode == ControllerMode.PC) { 
            //Cursor.visible = true; //menghilangkan cursor atau menyembunyikannya
            //Cursor.lockState = CursorLockMode.Confined; //mengkunci cursor agar tidak keluar dari game

            //jangan menggunakan code ini jika controller mode nya mode android, karena analog mobile akan mengalami bug
        }

        Debug.Log("Controller manager using: " + controllerMode.ToString());
    }

    private void Update () {
        Inputed();
        //float s = ControlSensitivity.Instance.sensitivity;
        ControlSensitivity cs = FindObjectOfType<ControlSensitivity>();
        sensitivty = cs.sensitivity;
    }

    private void LateUpdate () {
        Output();
    }

    private void Output () {
        Looking();
        Moving();
        Transition();
        //Animating();
    }

    private void Inputed () {
        switch(controllerMode) {
            case ControllerMode.PC :
                requirementMoveZRun = Input.GetAxis("Vertical") * walkSpeed;  

                Move.x = Input.GetAxis("Horizontal") * speed;
                Move.y = Input.GetAxis("Vertical") * speed;

                //currentLookDelta = Vector2.SmoothDamp(currentLookDelta, targetLookDelta, ref currentLookVelocity, smoothLook);

                Look.x += Input.GetAxis("Mouse X") * sensitivty * smoothLook * Time.timeScale;
                Look.y -= Input.GetAxis("Mouse Y") * sensitivty * smoothLook * Time.timeScale;

                isRunning = Input.GetKey(KeyCode.LeftShift) && requirementMoveZRun > (walkSpeed * 0.6f) && charcc.isGrounded && !CheckCrouch();
                isCrouching = Input.GetKey(KeyCode.C) && isRunning == false;

                canvasAndroid.SetActive(false);
                break;
            case ControllerMode.Android : 
                requirementMoveZRun = InputManager.instance.joystickMobile.Vertical * walkSpeed; 

                Move.x = InputManager.instance.joystickMobile.Horizontal * speed;
                Move.y = InputManager.instance.joystickMobile.Vertical * speed;

                for(int i = 0; i < Input.touchCount; i++) {
                    Touch touch = Input.GetTouch(i);
                    if(InputManager.instance.verifiedTouch(touch, Screen.width * screenTouchForCamera)) {
                        switch(touch.phase) {
                            case TouchPhase.Moved : 
                                Look.x += touch.deltaPosition.x * sensitivty * Time.deltaTime;
                                Look.y -= touch.deltaPosition.y * sensitivty * Time.deltaTime;
                            break;
                        }
                    }
                }   

                isRunning = mobileRun && requirementMoveZRun > (walkSpeed * 0.6f) && charcc.isGrounded && !CheckCrouch();
                isCrouching = mobileCrouch && isRunning == false;

                canvasAndroid.SetActive(true);
                break;
        }
    }

    private void Moving () {
        Vector3 newMove = new Vector3 (Move.x, 0, Move.y);
	    newMove = Vector3.ClampMagnitude (newMove, speed); //mengatur kecepatan bergerak secara diagonal, jika code ini dihilangkan maka bergerak secara diagonal akan lebih cepat dari bergerak dengan kecepatan yang kita tentukan
        newMove.y = -gravity; //gravitasi player
        newMove.y = AdjustVelocityToSlope(newMove).y; //untuk check apakah ground yang di injak itu menanjak atau sebaliknya 
	    newMove *= Time.deltaTime; //timedeltaTime agar gerakan player tidak kecepatan
	    newMove = transform.TransformDirection (newMove); 
        charcc.Move (newMove);
    }

    private void Looking () {
        Look.y = Mathf.Clamp(Look.y, minVerticalLook, maxVerticalLook); //membatasi melihat secara vertikal
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Look.x, transform.eulerAngles.z); //mengrotasikan bagian y (y = horizontal bagian rotasi) 
        CameraHolder.localEulerAngles = new Vector3(Look.y, CameraHolder.localEulerAngles.y, CameraHolder.localEulerAngles.z); //mengrotasikan bagian y (x = vertical bagian rotasi) 
    }

    /*private void Animating () {
        if(animator == null) return;
        float magnitude = charcc.velocity.magnitude/charcc.velocity.magnitude;
        animator.SetFloat("walkX", Move.x * magnitude);
        animator.SetFloat("walkZ", Move.y * magnitude);
    }*/

    public void ButtonMobile (string act) {
        if(act == "run") {
            mobileRun = !mobileRun;
            Debug.Log("Running: " + mobileRun.ToString());
        } else if(act == "crouch") {
            mobileCrouch = !mobileCrouch;
            Debug.Log("Crouching: " + mobileCrouch.ToString());
        }
    }

    private void Transition () {
        if(isRunning) {
            moveMode = MoveMode.Run;
        } else if(isCrouching || CheckCrouch()) {
            moveMode = MoveMode.Crouch;
        } else {
            moveMode = MoveMode.Walk;
        }

        //dibawah ini adalah transisi smooth antara perubahan nilai speed
        switch(moveMode) {
            case MoveMode.Crouch : 
                if(speed != crouchSpeed)
                    speed = Mathf.Lerp(speed, crouchSpeed, weightCrouch * Time.deltaTime);
            break;
            case MoveMode.Run : 
                if(speed != runSpeed)
                    speed = Mathf.Lerp(speed, runSpeed, 7 * Time.deltaTime);
            break;
            case MoveMode.Walk : 
                if(speed != walkSpeed)
                    speed = Mathf.Lerp(speed, walkSpeed, 7 * Time.deltaTime);
            break;
        }

        if(isCrouching || CheckCrouch()) {
            currentWeightCrouch = Mathf.MoveTowards(currentWeightCrouch, 1, weightCrouch * Time.deltaTime); //new height menjadi crouch height ketika player menekan tombol crouch
        } else {
            currentWeightCrouch = Mathf.MoveTowards(currentWeightCrouch, 0, weightCrouch * Time.deltaTime); //new height menjadi normal height ketika player melepas tombol crouch
        }

        charcc.height = Mathf.MoveTowards(normalHeight, crouchHeight, currentWeightCrouch); //transisi mengubah char.height menjadi newHeight
        charcc.center = new Vector3(charcc.center.x, charcc.height * 0.5f, charcc.center.z); //menyesuaikan posisi player ketika melakukan crouch 
        CameraHolder.transform.localPosition = new Vector3(CameraHolder.localPosition.x, charcc.height + 0.3f, CameraHolder.localPosition.z); //menyesuaikan posisi camera agar camera tersebut sesuai dengan posisi crouchnya
    }

    Vector3[] newVectorCheckCrouch;
    private bool CheckCrouch () {
        //dibawah ini adalah raycast yang posisinya di bagian kepala player, fungsinya ini untuk mengecek apakah diatas player ada benda atau tidak
        //jika ada benda maka player akan crouching
        float checkRayAbove = charcc.bounds.center.y + charcc.bounds.extents.y;  //memposisikan raycast di kepala player
        float checkRayFront = charcc.bounds.center.z + charcc.bounds.extents.z; //memposisikan raycast di kepala player bagian depannya
        float checkRayRight = charcc.bounds.center.x + charcc.bounds.extents.x; //memposisikan raycast di kepala player bagian kanan atau samping kanan
        float checkRayLeft = charcc.bounds.center.x - charcc.bounds.extents.x; ////memposisikan raycast di kepala player bagian kiri atau samping kiri
        float checkRayBackward = charcc.bounds.center.z - charcc.bounds.extents.z; //memposisikan raycast di kepala player bagian belakang
        newVectorCheckCrouch = new Vector3[]{
            new Vector3(transform.position.x, checkRayAbove, checkRayFront), 
            new Vector3(checkRayRight, checkRayAbove, transform.position.z),
            new Vector3(checkRayLeft, checkRayAbove, transform.position.z),
            new Vector3(transform.position.x, checkRayAbove, checkRayBackward)
        };
        bool CheckFront = RayGenerator(newVectorCheckCrouch[0]); //raycast cek
        bool checkRight = RayGenerator(newVectorCheckCrouch[1]);
        bool CheckLeft = RayGenerator(newVectorCheckCrouch[2]);
        bool CheckBackward = RayGenerator(newVectorCheckCrouch[3]);
        return (CheckFront || checkRight || CheckLeft || CheckBackward); //jika salah satu raycast mengenai benda makan checkCrouch == true
    }

    private bool RayGenerator (Vector3 position) {
        RaycastHit hit;
        return Physics.Raycast(position, Vector3.up, out hit, 1, crouchLayer);
        //benda yang akan tercek oleh raycast adalah benda yang memiliki layer crouchLayer
    }

    private Vector3 AdjustVelocityToSlope(Vector3 velocity) { //fix bug player melayang ketika berlari kebawah.
        var ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f)) {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopeRotation * velocity;

            if(adjustedVelocity.y < 0)
                return adjustedVelocity;
        }

        return velocity; 
    }

    public void SettingSensitivy(float range)
    {
        sensitivty = range;
    }


}

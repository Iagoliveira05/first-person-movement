
using System;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float SensitivityMobile = 20f;
    public float SensitivityDesktop = 100f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnTouchDevice.isOpenTutorial == false)
        {
            if (IsOnTouchDevice.GetTypeOfDevice() == "Mobile")
            {
                MovementMobile();
            }
            else
            {
                MovementKeyboard();
            }
        }
    }

    private void MovementMobile()
    {
        XMove = LockAxis.x * SensitivityMobile * Time.deltaTime;
        YMove = LockAxis.y * SensitivityMobile * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * XMove);
    }

    private void MovementKeyboard()
    {
        XMove = Input.GetAxis("Mouse X") * SensitivityDesktop * Time.deltaTime;
        YMove = Input.GetAxis("Mouse Y") * SensitivityDesktop * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * XMove);
    }
}

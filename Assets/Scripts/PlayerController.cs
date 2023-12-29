using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speedMove = 5f;
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (IsOnTouchDevice.isOpenTutorial == false )
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
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(speedMove * Time.deltaTime * move);
    }

    private void MovementKeyboard()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(speedMove * Time.deltaTime * move);
    }
}

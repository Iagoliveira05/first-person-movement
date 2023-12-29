using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UrlController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI txtButton;
    [SerializeField] private string url;

    private void Start()
    {
        if (IsOnTouchDevice.GetTypeOfDevice() == "Mobile")
        {
            txtButton.text = "ACESSAR";
        }
        else
        {
            txtButton.text = "[ SPACE ]";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("IsTrigger", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("IsTrigger", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonClick();
        }
    }

    public void ButtonClick()
    {
         Application.OpenURL(url);
    }
}

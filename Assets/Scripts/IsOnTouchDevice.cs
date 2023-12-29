using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnTouchDevice : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<GameObject> gameObjectsMobile;

    [SerializeField] GameObject pnlTutorialMobile;
    [SerializeField] GameObject pnlTutorialDesktop;

    [SerializeField] Animator _animator;


    public static bool isOpenTutorial;

    private static string typeOfDevice;
    void Start()
    {
        isOpenTutorial = true;
        if (SystemInfo.deviceType == DeviceType.Handheld)   // Mobile
        {
            typeOfDevice = "Mobile";
            MobileTutorial();
        }
        else
        {
            typeOfDevice = "Desktop";
            DesktopTutorial();
        }
        _animator.SetTrigger(typeOfDevice);
        
    }

    public static string GetTypeOfDevice()
    {
        return typeOfDevice;
    }
    
    private void MobileTutorial()
    {
        pnlTutorialDesktop.SetActive(false);
        pnlTutorialMobile.SetActive(true);
    }

    private void DesktopTutorial()
    {
        pnlTutorialMobile.SetActive(false);
        pnlTutorialDesktop.SetActive(true);
    }


    public void CloseTutorial()
    {
        isOpenTutorial = false;
        if (typeOfDevice == "Mobile")
        {
            ShowHUB();
        }
        else
        {
            HideHUB();
        }
    }


    private void ShowHUB()
    {
        foreach (var gameObject in gameObjectsMobile)
        {
            gameObject.SetActive(true);
        }
    }

    private void HideHUB()
    {
        foreach (var gameObject in gameObjectsMobile)
        {
            gameObject.SetActive(false);
        }
    }
}

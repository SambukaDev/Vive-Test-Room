using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public enum LocomotionMethod
{
    Teleport, Touchpad, Teleball
}


public class Manager : MonoBehaviour {

    public LocomotionMethod NewMethod;
    [HideInInspector] public LocomotionMethod ActiveMethod;

    public Slider CooldownSliderLeft;
    public Slider CooldownSliderRight;
    public GameObject PTLeft;
    public GameObject PTRight;
    public GameObject TMLeft;
    public GameObject TMRight;
    public GameObject TBLeft;
    public GameObject TBRight;

    private GameObject[] TeleportControllers;
    private GameObject[] TouchpadControllers;
    private GameObject[] TeleballControllers;
    private VRTK_SDKManager SDKManager;

    private GameObject[] Slopes;


    void Start ()
    {

        TeleportControllers = GameObject.FindGameObjectsWithTag("Teleport");
        TouchpadControllers = GameObject.FindGameObjectsWithTag("Touchpad");
        TeleballControllers = GameObject.FindGameObjectsWithTag("Teleball");

        SDKManager = gameObject.GetComponent<VRTK_SDKManager>();

        Slopes = GameObject.FindGameObjectsWithTag("Slope");

        foreach (var slope in Slopes)
        {
            slope.SetActive(false);
        }
    }


    private void Update()
    {
        if (NewMethod != ActiveMethod)
        {
            SwitchMethod();
        }
    }


    private void SwitchMethod()
    {
        switch(NewMethod)
        {
            case LocomotionMethod.Teleport:

                if (ActiveMethod.ToString() == "Touchpad")
                {
                    foreach (var slope in Slopes)
                    {
                        slope.SetActive(false);
                    }
                }

                if (CooldownSliderLeft.gameObject.activeSelf == false)
                    CooldownSliderLeft.gameObject.SetActive(true);

                if (CooldownSliderRight.gameObject.activeSelf == false)
                    CooldownSliderRight.gameObject.SetActive(true);


                SDKManager.scriptAliasLeftController = PTLeft;
                SDKManager.scriptAliasRightController = PTRight;
                SDKManager.TryLoadSDKSetup(0, false, SDKManager.setups);


                ActiveMethod = NewMethod;

                Debug.Log("SWITCHED TO " + NewMethod.ToString());

                break;




            case LocomotionMethod.Touchpad:

                foreach (var slope in Slopes)
                {
                    slope.SetActive(true);
                }

                if (CooldownSliderLeft.gameObject.activeSelf == true)
                    CooldownSliderLeft.gameObject.SetActive(false);

                if (CooldownSliderRight.gameObject.activeSelf == true)
                    CooldownSliderRight.gameObject.SetActive(false);

                SDKManager.scriptAliasLeftController = TMLeft;
                SDKManager.scriptAliasRightController = TMRight;
                SDKManager.TryLoadSDKSetup(0, false, SDKManager.setups);


                ActiveMethod = NewMethod;

                Debug.Log("SWITCHED TO " + NewMethod.ToString());

                break;




            case LocomotionMethod.Teleball:

                if (ActiveMethod.ToString() == "Touchpad")
                {
                    foreach (var slope in Slopes)
                    {
                        slope.SetActive(false);
                    }
                }

                if (CooldownSliderLeft.gameObject.activeSelf == true)
                    CooldownSliderLeft.gameObject.SetActive(false);

                if (CooldownSliderRight.gameObject.activeSelf == true)
                    CooldownSliderRight.gameObject.SetActive(false);

                SDKManager.scriptAliasLeftController = TBLeft;
                SDKManager.scriptAliasRightController = TBRight;
                SDKManager.TryLoadSDKSetup(0, false, SDKManager.setups);


                ActiveMethod = NewMethod;

                Debug.Log("SWITCHED TO " + NewMethod.ToString());

                break;
        }
    }


    private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("BUTTON TWO PRESSED!");
    }


    private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("BUTTON TWO RELEASED!");
    }
}

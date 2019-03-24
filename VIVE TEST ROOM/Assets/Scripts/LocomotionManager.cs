using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LocomotionManager : MonoBehaviour {

    public GameObject PlayArea;
    public GameObject LeftController;
    public GameObject RightController;
    public int NumLocomotionModes = 2;

    private VRTK_DashTeleport DashScript;
    private VRTK_ControllerEvents LeftControllerEvents;
    private VRTK_ControllerEvents RightControllerEvents;
    private int LocomotionMode = 0;

    private void Start()
    {
        //DashScript = PlayArea.GetComponent<VRTK_DashTeleport>();

        //LeftControllerEvents = LeftController.GetComponent<VRTK_ControllerEvents>();
        //RightControllerEvents = RightController.GetComponent<VRTK_ControllerEvents>();


        GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoPressed);
        GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTwoReleased);
    }


    private void LocomotionSwitcher()
    {

    }


    private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("BUTTON TWO PRESSED!");

        if (LocomotionMode == NumLocomotionModes) LocomotionMode = 0;
        else LocomotionMode++;

        LocomotionSwitcher();
    }


    private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("BUTTON TWO RELEASED!");


    }
}

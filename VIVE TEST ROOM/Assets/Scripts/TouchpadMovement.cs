using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TouchpadMovement : MonoBehaviour {


    //Reference to Children
    public GameObject PlayArea;
    public GameObject LeftController;
    public GameObject RightController;


    private void Enable()
    {
        PlayArea.AddComponent<VRTK_BodyPhysics>();
        PlayArea.AddComponent<VRTK_HeightAdjustTeleport>();
        PlayArea.AddComponent<VRTK_PolicyList>();
        PlayArea.AddComponent<VRTK_HeadsetCollision>();
        PlayArea.AddComponent<VRTK_HeadsetFade>();
        PlayArea.AddComponent<VRTK_HeadsetCollisionFade>();
        PlayArea.AddComponent<VRTK_PositionRewind>();


        LeftController.AddComponent<VRTK_TouchpadControl>();
        LeftController.AddComponent<VRTK_ControllerEvents>();
        LeftController.AddComponent<VRTK_InteractTouch>();
        LeftController.AddComponent<VRTK_InteractGrab>();


        RightController.AddComponent<VRTK_TouchpadControl>();
        RightController.AddComponent<VRTK_ControllerEvents>();
        RightController.AddComponent<VRTK_InteractTouch>();
        RightController.AddComponent<VRTK_InteractGrab>();

        SetAttributes();
    }


    public void SetAttributes()
    {

    }


    private void Disable()
    {
        Destroy(PlayArea.GetComponent<VRTK_BodyPhysics>());
        Destroy(PlayArea.GetComponent<VRTK_HeightAdjustTeleport>());
        Destroy(PlayArea.GetComponent<VRTK_PolicyList>());
        Destroy(PlayArea.GetComponent<VRTK_HeadsetCollision>());
        Destroy(PlayArea.GetComponent<VRTK_HeadsetFade>());
        Destroy(PlayArea.GetComponent<VRTK_HeadsetCollisionFade>());
        Destroy(PlayArea.GetComponent<VRTK_PositionRewind>());


        Destroy(LeftController.GetComponent<VRTK_TouchpadControl>());
        Destroy(LeftController.GetComponent<VRTK_ControllerEvents>());
        Destroy(LeftController.GetComponent<VRTK_InteractTouch>());
        Destroy(LeftController.GetComponent<VRTK_InteractGrab>());


        Destroy(RightController.GetComponent<VRTK_TouchpadControl>());
        Destroy(RightController.GetComponent<VRTK_ControllerEvents>());
        Destroy(RightController.GetComponent<VRTK_InteractTouch>());
        Destroy(RightController.GetComponent<VRTK_InteractGrab>());
    }

}

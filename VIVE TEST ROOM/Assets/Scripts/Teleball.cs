using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Teleball : MonoBehaviour {


    public GameObject BallPrefab;
    private Transform SpawnPoint;
    public GameObject CameraRig;

    private VRTK_ObjectAutoGrab AutoGrabScript;
    private VRTK_InteractTouch InteractTouch;
    private VRTK_InteractGrab InteractGrab;
    private GameObject Ball;


    private void Start()
    {
        GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);

        //Gets the button presses
        GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

        //Gets the grab scripts
        AutoGrabScript = GetComponent<VRTK_ObjectAutoGrab>();
        InteractTouch = GetComponent<VRTK_InteractTouch>();
        InteractGrab = GetComponent<VRTK_InteractGrab>();
    }


    //Spawns the ball in the players hand
    private void SpawnBall()
    {
        Ball = Instantiate(BallPrefab, SpawnPoint.position, SpawnPoint.rotation);

        InteractTouch.ForceStopTouching();
        InteractTouch.ForceTouch(Ball);
        InteractGrab.AttemptGrab();
    }


    //Destroys the ball
    private void DestroyBall()
    {
        DestroyImmediate(Ball);
        Ball = null;
    }


    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Trigger PRESSED!");

        //Gets the controllers transform
        SpawnPoint = GameObject.Find("[VRTK][AUTOGEN][P&T RightController][BasePointerRenderer_Origin_Smoothed]").transform;

        //If no ball(spawnball) else teleport
        if (!Ball)
        {
            SpawnBall();
        }
        else
        {
            //Gets the point of the enviroment directly below the ball
            Ray ground = new Ray(Ball.transform.position, Vector3.down);
            RaycastHit HitInfo;
            Physics.Raycast(ground, out HitInfo, Mathf.Infinity);

            //Teleports the player and destroys the ball
            Vector3 pos = new Vector3(Ball.transform.position.x, HitInfo.point.y, Ball.transform.position.z);
            CameraRig.transform.position = pos;
            DestroyBall();
        }
    }


    private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Trigger RELEASED!");

        //AutoGrabScript = new VRTK_ObjectAutoGrab;
        //AutoGrabScript.objectToGrab = Instantiate<BallPrefab, >;
            
        //    BallPrefab.GetComponent<VRTK_InteractableObject>();
    }


    private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Touchpad PRESSED!");

        if (Ball)DestroyBall();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PointAndTeleport : MonoBehaviour {


    //Reference to Locomotion Controllers
    private GameObject PlayArea;
    private GameObject LeftController;
    private GameObject RightController;

    //PlayArea Properties
    private VRTK_BodyPhysics BodyPhysics;
    private VRTK_DashTeleport DashTeleport;
    private VRTK_PolicyList PolicyList;

    //Left Controller Properties
    private VRTK_ControllerEvents LeftControllerEvents;
    private VRTK_InteractTouch LeftInteractTouch;
    private VRTK_InteractGrab LeftInteractGrab;
    private VRTK_Pointer LeftPointer;
    private VRTK_BezierPointerRenderer LeftPointerRenderer;

    //Right Controller Properties
    private VRTK_ControllerEvents RightControllerEvents;
    private VRTK_InteractTouch RightInteractTouch;
    private VRTK_InteractGrab RightInteractGrab;
    private VRTK_Pointer RightPointer;
    private VRTK_BezierPointerRenderer RightPointerRenderer;


    public void SetLocomotionControllers(GameObject playarea, GameObject leftcontroller, GameObject rightcontroller)
    {
        PlayArea = playarea;
        LeftController = leftcontroller;
        RightController = rightcontroller;
    }


    public void Enable()
    {
        BodyPhysics = PlayArea.AddComponent<VRTK_BodyPhysics>();
        DashTeleport = PlayArea.AddComponent<VRTK_DashTeleport>();
        PolicyList = PlayArea.AddComponent<VRTK_PolicyList>();

        LeftControllerEvents = LeftController.AddComponent<VRTK_ControllerEvents>();
        LeftInteractTouch = LeftController.AddComponent<VRTK_InteractTouch>();
        LeftInteractGrab = LeftController.AddComponent<VRTK_InteractGrab>();
        LeftPointer = LeftController.AddComponent<VRTK_Pointer>();
        LeftPointerRenderer = LeftController.AddComponent<VRTK_BezierPointerRenderer>();

        RightControllerEvents = RightController.AddComponent<VRTK_ControllerEvents>();
        RightInteractTouch = RightController.AddComponent<VRTK_InteractTouch>();
        RightInteractGrab = RightController.AddComponent<VRTK_InteractGrab>();
        RightPointer = RightController.AddComponent<VRTK_Pointer>();
        RightPointerRenderer = RightController.AddComponent<VRTK_BezierPointerRenderer>();

        SetAttributes();
    }


    private void SetAttributes()
    {
        //PlayArea BodyPhysics
        BodyPhysics.enableTeleport = true;
        BodyPhysics.enableBodyCollisions = false;
        BodyPhysics.ignoreGrabbedCollisions = true;
        BodyPhysics.headsetYOffset = 0.2f;
        BodyPhysics.movementThreshold = 0.0015f;
        BodyPhysics.playAreaMovementThreshold = 0.00075f;
        BodyPhysics.standingHistorySamples = 5;
        BodyPhysics.leanYThreshold = 0.5f;
        BodyPhysics.stepUpYOffset = 0.15f;
        BodyPhysics.stepThicknessMultiplier = 0.5f;
        BodyPhysics.stepDropThreshold = 0.08f;
        BodyPhysics.fallRestriction = VRTK_BodyPhysics.FallingRestrictors.NoRestriction;
        BodyPhysics.gravityFallYThreshold = 1f;
        BodyPhysics.blinkYThreshold = 0.15f;
        BodyPhysics.floorHeightTolerance = 0.001f;
        BodyPhysics.fallCheckPrecision = 5;

        //PlayArea DashTeleport
        DashTeleport.blinkTransitionSpeed = 0f;
        DashTeleport.distanceBlinkDelay = 0f;
        DashTeleport.headsetPositionCompensation = true;
        DashTeleport.navMeshLimitDistance = 0f;
        DashTeleport.normalLerpTime = 0.1f;
        DashTeleport.minSpeedMps = 50f;
        DashTeleport.capsuleTopOffset = 0.2f;
        DashTeleport.capsuleBottomOffset = 0.5f;
        DashTeleport.capsuleRadius = 0.5f;



        //Left Controller Events
        LeftControllerEvents.pointerToggleButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        LeftControllerEvents.pointerSetButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        LeftControllerEvents.grabToggleButton = VRTK_ControllerEvents.ButtonAlias.GripPress;
        LeftControllerEvents.useToggleButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        LeftControllerEvents.uiClickButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        LeftControllerEvents.menuToggleButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;
        LeftControllerEvents.axisFidelity = 1;
        LeftControllerEvents.triggerClickThreshold = 1f;
        LeftControllerEvents.triggerForceZeroThreshold = 0.01f;
        LeftControllerEvents.triggerAxisZeroOnUntouch = false;
        LeftControllerEvents.gripClickThreshold = 1;
        LeftControllerEvents.gripForceZeroThreshold = 0.01f;
        LeftControllerEvents.gripAxisZeroOnUntouch = false;

        //Left Controller Interact Grab
        LeftInteractGrab.grabButton = VRTK_ControllerEvents.ButtonAlias.GripPress;
        LeftInteractGrab.grabPrecognition = 0f;
        LeftInteractGrab.throwMultiplier = 1;
        LeftInteractGrab.createRigidBodyWhenNotTouching = false;

        //Left Controller Pointer
        LeftPointer.enableTeleport = true;
        LeftPointer.pointerRenderer = LeftPointerRenderer;
        LeftPointer.activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        LeftPointer.holdButtonToActivate = true;
        LeftPointer.activateOnEnable = false;
        LeftPointer.activationDelay = 0f;
        LeftPointer.selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        LeftPointer.selectOnPress = false;
        LeftPointer.selectionDelay = 0f;
        LeftPointer.selectAfterHoverDuration = 0f;
        LeftPointer.interactWithObjects = false;
        LeftPointer.grabToPointerTip = false;

        //Left Controller Pointer Renderer
        LeftPointerRenderer.validCollisionColor = new Color(45, 199, 45);
        LeftPointerRenderer.invalidCollisionColor = Color.red;
        LeftPointerRenderer.tracerVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
        LeftPointerRenderer.cursorVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
        LeftPointerRenderer.maximumLength.x = 7.5f;
        LeftPointerRenderer.maximumLength.y = Mathf.Infinity;
        LeftPointerRenderer.tracerDensity = 15;
        LeftPointerRenderer.cursorRadius = 0.5f;
        LeftPointerRenderer.heightLimitAngle = 45;
        LeftPointerRenderer.curveOffset = 1;
        LeftPointerRenderer.rescaleTracer = false;
        LeftPointerRenderer.cursorMatchTargetRotation = false;
        LeftPointerRenderer.collisionCheckFrequency = 0;
        //LeftPointerRenderer.customCursor



        //Right Controller Events
        RightControllerEvents.pointerToggleButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        RightControllerEvents.pointerSetButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        RightControllerEvents.grabToggleButton = VRTK_ControllerEvents.ButtonAlias.GripPress;
        RightControllerEvents.useToggleButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        RightControllerEvents.uiClickButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
        RightControllerEvents.menuToggleButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;
        RightControllerEvents.axisFidelity = 1;
        RightControllerEvents.triggerClickThreshold = 1f;
        RightControllerEvents.triggerForceZeroThreshold = 0.01f;
        RightControllerEvents.triggerAxisZeroOnUntouch = false;
        RightControllerEvents.gripClickThreshold = 1;
        RightControllerEvents.gripForceZeroThreshold = 0.01f;
        RightControllerEvents.gripAxisZeroOnUntouch = false;

        //Right Controller Interact Grab
        RightInteractGrab.grabButton = VRTK_ControllerEvents.ButtonAlias.GripPress;
        RightInteractGrab.grabPrecognition = 0f;
        RightInteractGrab.throwMultiplier = 1;
        RightInteractGrab.createRigidBodyWhenNotTouching = false;

        //Right Controller Pointer
        RightPointer.enableTeleport = true;
        RightPointer.pointerRenderer = RightPointerRenderer;
        RightPointer.activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        RightPointer.holdButtonToActivate = true;
        RightPointer.activateOnEnable = false;
        RightPointer.activationDelay = 0f;
        RightPointer.selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
        RightPointer.selectOnPress = false;
        RightPointer.selectionDelay = 0f;
        RightPointer.selectAfterHoverDuration = 0f;
        RightPointer.interactWithObjects = false;
        RightPointer.grabToPointerTip = false;

        //Right Controller Pointer Renderer
        RightPointerRenderer.validCollisionColor = new Color(45, 199, 45);
        RightPointerRenderer.invalidCollisionColor = Color.red;
        RightPointerRenderer.tracerVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
        RightPointerRenderer.cursorVisibility = VRTK_BasePointerRenderer.VisibilityStates.OnWhenActive;
        RightPointerRenderer.maximumLength.x = 7.5f;
        RightPointerRenderer.maximumLength.y = Mathf.Infinity;
        RightPointerRenderer.tracerDensity = 15;
        RightPointerRenderer.cursorRadius = 0.5f;
        RightPointerRenderer.heightLimitAngle = 45;
        RightPointerRenderer.curveOffset = 1;
        RightPointerRenderer.rescaleTracer = false;
        RightPointerRenderer.cursorMatchTargetRotation = false;
        RightPointerRenderer.collisionCheckFrequency = 0;
        //RightPointerRenderer.customCursor
    }


    public void Disable()
    {
        Destroy(BodyPhysics);
        Destroy(DashTeleport);
        Destroy(PolicyList);

        Destroy(LeftControllerEvents);
        Destroy(LeftInteractTouch);
        Destroy(LeftInteractGrab);
        Destroy(LeftPointer);
        Destroy(LeftPointerRenderer);

        Destroy(RightControllerEvents);
        Destroy(RightInteractTouch);
        Destroy(RightInteractGrab);
        Destroy(RightPointer);
        Destroy(RightPointerRenderer);
    }

}

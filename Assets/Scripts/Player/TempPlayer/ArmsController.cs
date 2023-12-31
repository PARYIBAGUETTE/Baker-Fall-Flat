using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsController : MonoBehaviour
{
    private PlayerInputAction.PlayerActions playerAction;

    private Animator animator;

    [SerializeField]
    private GrabHandler leftGrab;

    [SerializeField]
    private GrabHandler rightGrab;

    private void OnDisable()
    {
        DelInputEvent();
    }

    public void Init(DefaultBehavior controller)
    {
        animator = controller.ActiveRagdoll.AnimatedAnimator;
        playerAction = controller.PlayerAction;
        AddInputEvent();
    }

    private void AddInputEvent()
    {
        playerAction.LeftClick.started += LeftClickDown;
        playerAction.LeftClick.canceled += LeftClickUp;

        playerAction.RightClick.started += RightClickDown;
        playerAction.RightClick.canceled += RightClickUp;
    }

    private void DelInputEvent()
    {
        playerAction.LeftClick.started -= LeftClickDown;
        playerAction.LeftClick.canceled -= LeftClickUp;

        playerAction.RightClick.started -= RightClickDown;
        playerAction.RightClick.canceled -= RightClickUp;
    }

    public void LeftClickDown(InputAction.CallbackContext context)
    {
        animator.SetBool("isUpLeftArm", true);
        leftGrab.StartGrabAction();
    }

    public void LeftClickUp(InputAction.CallbackContext context)
    {
        animator.SetBool("isUpLeftArm", false);
        leftGrab.EndGrabAction();
    }

    public void RightClickDown(InputAction.CallbackContext context)
    {
        animator.SetBool("IsUpRightArm", true);
        rightGrab.StartGrabAction();
    }

    public void RightClickUp(InputAction.CallbackContext context)
    {
        animator.SetBool("IsUpRightArm", false);
        rightGrab.EndGrabAction();
    }
}

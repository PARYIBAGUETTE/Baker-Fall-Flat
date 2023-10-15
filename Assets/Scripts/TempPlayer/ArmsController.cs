using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerActions playerAction;

    private Animator animator;
    [SerializeField] private Rigidbody leftArm;
    [SerializeField] private Rigidbody rightArm;
    [SerializeField] private GrabHandler leftGrab;
    [SerializeField] private GrabHandler rightGrab;


    public void Init(PlayerController controller)
    {
        animator = controller.Animator;
        playerInputAction = controller.PlayerInputAction;
        playerAction = controller.PlayerAction;

        DelInputEvent();
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
        Debug.Log("다운");
        animator.SetBool("isUpLeftArm", true);
        leftGrab.StartGrabAction();
    }

    public void LeftClickUp(InputAction.CallbackContext context)
    {
        Debug.Log("업");
        animator.SetBool("isUpLeftArm", false);
        leftGrab.EndGrabAction();
    }

    public void RightClickDown(InputAction.CallbackContext context)
    {
        Debug.Log("다운");
        animator.SetBool("IsUpRightArm", true);
        rightGrab.StartGrabAction();
    }

    public void RightClickUp(InputAction.CallbackContext context)
    {
        Debug.Log("업");
        animator.SetBool("IsUpRightArm", false);
        rightGrab.EndGrabAction();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpForce = 3.0f;

    private float gravity = -9.81f;
    private Vector3 moveDirection;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void JumpTo()
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    private void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsRun", true);
            hips.AddForce(hips.transform.right * speed);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsStrafeLeft", true);
            hips.AddForce(hips.transform.forward * strafeSpeed);
        }
        else
        {
            animator.SetBool("IsStrafeLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsRunBack", true);
            hips.AddForce(-hips.transform.right * speed);
        }
        else
        {
            animator.SetBool("IsRunBack", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsStrafeRight", true);
            hips.AddForce(-hips.transform.forward * strafeSpeed);
        }
        else
        {
            animator.SetBool("IsStrafeRight", false);
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}

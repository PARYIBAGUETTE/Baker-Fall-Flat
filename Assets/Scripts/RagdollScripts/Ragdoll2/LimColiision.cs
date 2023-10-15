using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimColiision : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
        playerController = GameObject
            .FindObjectOfType<PlayerController>()
            .GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        playerController.isGrounded = true;
    }
}

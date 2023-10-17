using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    PlayerController controller;


    // 점프의 실행이 이상하면 여길 체크해볼 것
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        controller.IsGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        controller.IsGround = true;
    }

    public void Init(PlayerController controller)
    {
        this.controller = controller;
    }
}

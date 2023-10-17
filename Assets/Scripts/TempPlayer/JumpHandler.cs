using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    PlayerController controller;


    // ������ ������ �̻��ϸ� ���� üũ�غ� ��
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : TriggerObject
{
    private Animator anim;
    private CapsuleCollider coll;

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PRESSED!");
            anim.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Inactivate();
    }
}

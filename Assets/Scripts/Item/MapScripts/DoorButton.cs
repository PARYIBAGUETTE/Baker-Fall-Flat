using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : TriggerObject
{
    private Animator anim;
    //[SerializeField] private Animator animDoor;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        anim.SetTrigger("DoPress");
    //        animDoor.SetTrigger("DoOpen");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Activate();

        if (other.CompareTag("Player"))
        {
            Debug.Log("PRESSED!");
            anim.SetTrigger("DoPress");
            //animDoor.SetTrigger("DoOpen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Inactivate();
    }
}

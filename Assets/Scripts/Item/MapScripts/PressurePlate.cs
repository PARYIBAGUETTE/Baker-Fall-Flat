using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : TriggerObject
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Activate();
    }

    private void OnTriggerExit(Collider other)
    {
        Inactivate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private bool isDown = false;

    public bool IsDown { get; }

    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isDown = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        isDown = false;
    }
}

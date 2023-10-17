using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour, IWorkingObject
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private bool isLocked;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isLocked)
        {
            rigidbody.isKinematic = true;
        }
    }

    void IWorkingObject.Work()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        
    }
}

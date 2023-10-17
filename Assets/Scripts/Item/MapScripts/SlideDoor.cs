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

    void IWorkingObject.DoWork()
    {
        OpenDoor();
    }

    void IWorkingObject.UndoWork()
    {
        CloseDoor();
    }

    private void OpenDoor()
    {
        //문 열리는 애니메이션 실행
    }

    private void CloseDoor()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour, IWorkingObject
{
    private Rigidbody rigidbody;
    [SerializeField] private bool isLocked;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //isLocked 설정이라면 OpenDoor, CloseDoor 메소드를 실행시키는 트리거로만 문 여닫기가 가능해진다. 
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
        Debug.Log("Door Open!!!");
        //문 열리는 애니메이션 실행
    }

    private void CloseDoor()
    {
        Debug.Log("Door Close!!!");
        //문 닫히는 애니메이션 실행
    }
}

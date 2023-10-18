using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour, IWorkingObject
{
    private Rigidbody rigid;
    private Animator anim;

    [SerializeField] private bool isLocked;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //isLocked 설정이라면 OpenDoor, CloseDoor 메소드를 실행시키는 트리거로만 문 여닫기가 가능해진다. 
        if (isLocked)
        {
            rigid.isKinematic = true;
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
        //anim.ResetTrigger("DoClose");
        anim.SetBool("IsOpen", true);
        //문 열리는 애니메이션 실행
        anim.SetTrigger("DoOpen");
    }

    private void CloseDoor()
    {
        Debug.Log("Door Close!!!");
        anim.SetBool("IsOpen", false);
        //문 닫히는 애니메이션 실행

        //anim.SetTrigger("DoClose");
    }
}

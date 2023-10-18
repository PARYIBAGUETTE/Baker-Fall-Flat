using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingLog : MonoBehaviour, IWorkingObject
{
    [SerializeField] private float moveSpeed = 0.01f;
    
    //true 라면 회전하는 상태가 된다.
    [SerializeField] private bool isWorking = true;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        RotateLog();
    }

    void IWorkingObject.DoWork()
    {
        ToggleRotating();
    }

    void IWorkingObject.UndoWork()
    {
        ToggleRotating();
    }

    private void ToggleRotating()
    {
        Debug.Log("Toggle Rotating");
        isWorking = !isWorking;
    }

    private void RotateLog()
    {
        if (isWorking)
        {
            gameObject.transform.Rotate(Vector3.up*2);
        }
    }
}

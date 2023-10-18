using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour, IWorkingObject
{
    private enum Type { Button, Pressure }

    private Vector3 start;
    [SerializeField] private Transform goal;
    [SerializeField] private Type type;
    [SerializeField] private float moveSpeed;

    private bool isPressed = false;
    private bool isGoal = false;

    private void Awake()
    {
        start = transform.position;
    }

    private void FixedUpdate()
    {
        MoveDoor();
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
        if (!isPressed) isPressed = true;
    }

    private void CloseDoor()
    {
        if (isPressed) isPressed = false;
    }

    private void MoveDoor()
    {
        switch (type)
        {
            case Type.Button:
                if (isPressed)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goal.position, Time.timeScale * moveSpeed);
                }
                break;
            case Type.Pressure:
                if (isPressed)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goal.position, Time.timeScale * moveSpeed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, start, Time.timeScale * moveSpeed);
                }
                break;
        }
    }
}

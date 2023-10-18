using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IWorkingObject
{
    private Vector3 start;
    [SerializeField] private Transform goal;

    private bool isPressed = false;
    private bool isGoal = false;

    private void Awake()
    {
        start = transform.position;
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            if (!isGoal)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal.position, Time.deltaTime * 1.0f);

                if (transform.position.y >= goal.position.y)
                {
                    isGoal = true;
                    isPressed = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * 1.0f);

                if (transform.position.y <= start.y)
                {
                    isGoal = false;
                    isPressed = false;
                }
            }
        }
    }

    void IWorkingObject.DoWork()
    {
        WorkElevator();
    }

    void IWorkingObject.UndoWork()
    {
        
    }

    private void WorkElevator()
    {
        if (!isPressed) isPressed = true;
    }
}

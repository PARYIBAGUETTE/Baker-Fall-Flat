using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IWorkingObject
{
    private Vector3 start;
    [SerializeField] private Transform goal;
    [SerializeField] private float moveSpeed = 1.0f;

    private bool isPressed = false;
    private bool isGoal = false;

    private void Awake()
    {
        start = transform.position;
    }

    private void FixedUpdate()
    {
        MoveElevator();
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
        Debug.Log("Elevator Working");
        if (!isPressed) isPressed = true;
    }

    private void MoveElevator()
    {
        if (isPressed)
        {
            if (!isGoal)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal.position, Time.deltaTime * moveSpeed);

                if (transform.position.y >= goal.position.y)
                {
                    isGoal = true;
                    isPressed = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * moveSpeed);

                if (transform.position.y <= start.y)
                {
                    isGoal = false;
                    isPressed = false;
                }
            }
        }
    }
}

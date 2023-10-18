using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 멤버변수인 GameObject go 는 반드시 IWorkingObject 스크립트가 연결된 객체여야 한다.
/// </summary>
public class TriggerObject : MonoBehaviour
{
    [SerializeField] private bool isActivate = false;
    [SerializeField] private GameObject go;
    private IWorkingObject workingObject;

    private void Awake()
    {
        Debug.Log(go);
        workingObject = go.GetComponent<IWorkingObject>();
    }

    public bool IsActivate
    {
        get { return isActivate; }
    }

    public IWorkingObject WorkingObject
    {
        get { return workingObject; }
    }

    protected void Activate()
    {
        isActivate = true;
        if(workingObject != null)
        {
            Debug.Log("Active!!!");
            workingObject.DoWork();
        }
    }

    protected void Inactivate()
    {
        isActivate = false;
        if (workingObject != null)
        {
            Debug.Log("Inactive!!!");
            workingObject.UndoWork();
        }
    }
}

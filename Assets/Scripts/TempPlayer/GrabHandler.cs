using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHandler : MonoBehaviour
{
    [SerializeField]
    private HingeJoint joint;
    private Rigidbody grabObj;

    [SerializeField]
    private Collider coll;

    public void StartGrabAction()
    {
        coll.enabled = true;
    }

    public void EndGrabAction()
    {
        grabObj = null;
        joint.connectedBody = null;
        coll.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.TryGetComponent(out grabObj);
        joint.connectedBody = grabObj;
    }
}

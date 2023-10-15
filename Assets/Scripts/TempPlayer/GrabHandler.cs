using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHandler : MonoBehaviour
{
    private Transform grabObj;
    [SerializeField] private Collider coll;

    public void StartGrabAction()
    {
        coll.enabled = true;
    }

    public void EndGrabAction()
    {
        StopCoroutine(nameof(MoveGrabObj));
        grabObj = null;
        coll.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        grabObj = collision.gameObject.transform;
        StartCoroutine(nameof(MoveGrabObj));
    }

    IEnumerator MoveGrabObj()
    {
        while (grabObj != null)
        {
            grabObj.transform.Translate(transform.position);
            yield return null;
            //
        }
    }


}

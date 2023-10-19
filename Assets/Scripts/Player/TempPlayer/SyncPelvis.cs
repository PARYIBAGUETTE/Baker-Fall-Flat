using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPelvis : MonoBehaviour
{
    [SerializeField] Transform pelvis;


    private void FixedUpdate()
    {
        transform.position = pelvis.position;
    }
    private void Update()
    {
        transform.position = pelvis.position;

    }

}

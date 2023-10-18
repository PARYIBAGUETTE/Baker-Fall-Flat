using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigid : MonoBehaviour
{
    [SerializeField] private Transform rigid;

    private void Update()
    {
        float Y = rigid.position.y;

        transform.position += (Y- transform.position.y) * Vector3.up;
    }
}

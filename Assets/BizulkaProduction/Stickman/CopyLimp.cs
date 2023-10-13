using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CopyLimp : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    [SerializeField] private ConfigurableJoint joint;

    private Quaternion targetInitRot;

    private void Awake()
    {
        this.joint = GetComponent<ConfigurableJoint>();
        this.targetInitRot = targetLimb.transform.localRotation;
    }

    private void FixedUpdate()
    {
            
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitRot;
    }
}

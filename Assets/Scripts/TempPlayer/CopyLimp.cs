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
        joint = GetComponent<ConfigurableJoint>();
        targetInitRot = targetLimb.transform.localRotation;
    }

    private void FixedUpdate()
    {
        joint.targetRotation = CopyRotation();
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * targetInitRot;
    }
}

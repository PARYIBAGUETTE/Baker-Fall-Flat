using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    ConfigurableJoint configurableJoint;
    Quaternion targetInitialRotation;

    private void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
        targetInitialRotation = targetLimb.transform.localRotation;
    }

    void Update()
    {
        ConfigurableJointExtensions.SetTargetRotationLocal(
            GetComponent<ConfigurableJoint>(),
            targetLimb.localRotation,
            transform.localRotation
        );
    }

    private void FixedUpdate()
    {
        CopyRotation();
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(targetLimb.localRotation) * targetInitialRotation;
    }
}

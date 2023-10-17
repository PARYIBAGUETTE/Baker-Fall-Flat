using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    [SerializeField]
    private Transform targetLimb;

    private ConfigurableJoint configurableJoint;

    Quaternion targetInitialRotation;

    private void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
        targetInitialRotation = targetLimb.transform.localRotation;

        CopyRotation();
    }

    void Update()
    {
        // ConfigurableJointExtensions.SetTargetRotationLocal(
        //     GetComponent<ConfigurableJoint>(),
        //     targetLimb.localRotation,
        //     transform.localRotation
        // );
    }

    private void FixedUpdate()
    {
        configurableJoint.targetRotation = CopyRotation();
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(targetLimb.localRotation) * targetInitialRotation;
    }

    // ConfigurableJointExtensions.SetTargetRotationLocal(
    //     GetComponent<ConfigurableJoint>(),
    //     targetLimb.localRotation,
    //     transform.localRotation
    // );
}

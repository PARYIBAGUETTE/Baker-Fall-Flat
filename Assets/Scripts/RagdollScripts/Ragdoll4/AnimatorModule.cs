using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorModule : MonoBehaviour
{
    [SerializeField]
    protected ActiveRagdoll _activeRagdoll;
    public ActiveRagdoll ActiveRagdoll
    {
        get { return _activeRagdoll; }
    }

    [Header("--- BODY ---")]
    private Quaternion[] _initialJointsRotation;
    private ConfigurableJoint[] _joints;
    private Transform[] _animatedBones;

    void Start()
    {
        _joints = _activeRagdoll.Joints;
        _animatedBones = _activeRagdoll.AnimatedBones;

        _initialJointsRotation = new Quaternion[_joints.Length];
        for (int i = 0; i < _joints.Length; i++)
        {
            _initialJointsRotation[i] = _joints[i].transform.localRotation;
        }
    }

    void Update()
    {
        UpdateJointTargets();
    }

    private void UpdateJointTargets()
    {
        for (int i = 0; i < _joints.Length; i++)
        {
            ConfigurableJointExtensions.SetTargetRotationLocal(
                _joints[i],
                _animatedBones[i].localRotation,
                _initialJointsRotation[i]
            );
        }
    }
}

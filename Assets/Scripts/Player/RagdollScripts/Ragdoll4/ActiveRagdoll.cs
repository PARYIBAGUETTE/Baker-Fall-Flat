using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveRagdoll : MonoBehaviour
{
#region 변수
    [Header("--- BODY ---")]
    [SerializeField]
    private Transform _animatedTorso;
    public Transform AnimatedTorso
    {
        get { return _animatedTorso; }
    }

    [SerializeField]
    private Rigidbody _physicalTorso;
    public Rigidbody PhysicalTorso
    {
        get { return _physicalTorso; }
    }

    public Transform[] AnimatedBones;

    [SerializeField] ConfigurableJoint[] joint;
    public ConfigurableJoint[] Joints 
    { 
        get { return joint; } 
    }

    [Header("--- ANIMATORS ---")]
    [SerializeField]
    private Animator _animatedAnimator;
    public Animator AnimatedAnimator
    {
        get { return _animatedAnimator; }
        private set { _animatedAnimator = value; }
    }

    [SerializeField]
    private Animator _physicalAnimator;

    #endregion

    #region 인스펙터 창 세팅
    private void OnValidate()
    {
        Animator[] animators = GetComponentsInChildren<Animator>();

        if (animators.Length >= 2)
        {
            if (_animatedAnimator == null)
                _animatedAnimator = animators[0];

            if (_physicalAnimator == null)
                _physicalAnimator = animators[1];

            if (_animatedTorso == null)
                _animatedTorso = _animatedAnimator.GetBoneTransform(HumanBodyBones.Hips);

            if (_physicalTorso == null)
                _physicalTorso = _physicalAnimator
                    .GetBoneTransform(HumanBodyBones.Hips)
                    .GetComponent<Rigidbody>();
        }
    }
    #endregion

    //private void Awake()
    //{
    //    //if (Joints == null)
    //    //{
    //    //    // 개선 필요
    //    //    var temp = _physicalTorso?.GetComponentsInChildren<ConfigurableJoint>().ToList();
    //    //    var List = new List<ConfigurableJoint>();
    //    //    foreach (var joint in temp)
    //    //    {
    //    //        if (joint.gameObject.CompareTag("Player"))
    //    //            continue;

    //    //        List.Add(joint);
    //    //    }
    //    //    Joints = List.ToArray();
    //    //}
    //}
}

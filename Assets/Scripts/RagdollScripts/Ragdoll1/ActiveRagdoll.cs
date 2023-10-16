#pragma warning disable 649

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ActiveRagdoll
{
    [RequireComponent(typeof(InputModule))]
    public class ActiveRagdoll : MonoBehaviour
    {
        [Header("--- GENERAL ---")]
        [SerializeField]
        private int _solverIterations = 12;

        [SerializeField]
        private int _velSolverIterations = 4;

        [SerializeField]
        private float _maxAngularVelocity = 50;
        public int SolverIterations
        {
            get { return _solverIterations; }
        }
        public int VelSolverIterations
        {
            get { return _velSolverIterations; }
        }
        public float MaxAngularVelocity
        {
            get { return _maxAngularVelocity; }
        }

        public InputModule Input { get; private set; }

        /// <summary> 이 Active Ragdoll 인스턴스의 고유 ID입니다. </summary>
        public uint ID { get; private set; }
        private static uint _ID_COUNT = 0;

        [Header("--- BODY ---")]
        [SerializeField]
        private Transform _animatedTorso;

        [SerializeField]
        private Rigidbody _physicalTorso;
        public Transform AnimatedTorso
        {
            get { return _animatedTorso; }
        }
        public Rigidbody PhysicalTorso
        {
            get { return _physicalTorso; }
        }

        public Transform[] AnimatedBones { get; private set; }
        public ConfigurableJoint[] Joints { get; private set; }
        public Rigidbody[] Rigidbodies { get; private set; }

        [SerializeField]
        private List<BodyPart> _bodyParts;
        public List<BodyPart> BodyParts
        {
            get { return _bodyParts; }
        }

        [Header("--- ANIMATORS ---")]
        [SerializeField]
        private Animator _animatedAnimator;

        [SerializeField]
        private Animator _physicalAnimator;
        public Animator AnimatedAnimator
        {
            get { return _animatedAnimator; }
            private set { _animatedAnimator = value; }
        }

        public AnimatorHelper AnimatorHelper { get; private set; }

        /// <summary> 애니메이션 본체의 회전을 물리적 본체의 회전으로 계속 설정할지 여부입니다.</summary>
        public bool SyncTorsoPositions { get; set; } = true;
        public bool SyncTorsoRotations { get; set; } = true;

        private void OnValidate()
        {
            // 필요한 참조를 자동으로 검색합니다
            var animators = GetComponentsInChildren<Animator>();
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

            if (_bodyParts.Count == 0)
                GetDefaultBodyParts();
        }

        private void Awake()
        {
            ID = _ID_COUNT++;

            if (AnimatedBones == null)
                AnimatedBones = _animatedTorso?.GetComponentsInChildren<Transform>();
            if (Joints == null)
                Joints = _physicalTorso?.GetComponentsInChildren<ConfigurableJoint>();

            Debug.Log(
                "Joints Name : " + _physicalTorso?.GetComponentsInChildren<ConfigurableJoint>()
            );

            if (Rigidbodies == null)
                Rigidbodies = _physicalTorso?.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in Rigidbodies)
            {
                rb.solverIterations = _solverIterations;
                rb.solverVelocityIterations = _velSolverIterations;
                rb.maxAngularVelocity = _maxAngularVelocity;
            }

            foreach (BodyPart bodyPart in _bodyParts)
                bodyPart.Init();

            AnimatorHelper = _animatedAnimator.gameObject.AddComponent<AnimatorHelper>();
            if (TryGetComponent(out InputModule temp))
                Input = temp;
#if UNITY_EDITOR
            else
                Debug.LogError(
                    "InputModule could not be found. An ActiveRagdoll must always have"
                        + "a peer InputModule."
                );
#endif
        }

        private void GetDefaultBodyParts()
        {
            _bodyParts.Add(
                new BodyPart("Head Neck", TryGetJoints(HumanBodyBones.Head, HumanBodyBones.Neck))
            );
            _bodyParts.Add(
                new BodyPart(
                    "Torso",
                    TryGetJoints(
                        HumanBodyBones.Spine,
                        HumanBodyBones.Chest,
                        HumanBodyBones.UpperChest
                    )
                )
            );
            _bodyParts.Add(
                new BodyPart(
                    "Left Arm",
                    TryGetJoints(
                        HumanBodyBones.LeftUpperArm,
                        HumanBodyBones.LeftLowerArm,
                        HumanBodyBones.LeftHand
                    )
                )
            );
            _bodyParts.Add(
                new BodyPart(
                    "Right Arm",
                    TryGetJoints(
                        HumanBodyBones.RightUpperArm,
                        HumanBodyBones.RightLowerArm,
                        HumanBodyBones.RightHand
                    )
                )
            );
            _bodyParts.Add(
                new BodyPart(
                    "Left Leg",
                    TryGetJoints(
                        HumanBodyBones.LeftUpperLeg,
                        HumanBodyBones.LeftLowerLeg,
                        HumanBodyBones.LeftFoot
                    )
                )
            );
            _bodyParts.Add(
                new BodyPart(
                    "Right Leg",
                    TryGetJoints(
                        HumanBodyBones.RightUpperLeg,
                        HumanBodyBones.RightLowerLeg,
                        HumanBodyBones.RightFoot
                    )
                )
            );
        }

        private List<ConfigurableJoint> TryGetJoints(params HumanBodyBones[] bones)
        {
            List<ConfigurableJoint> jointList = new List<ConfigurableJoint>();
            foreach (HumanBodyBones bone in bones)
            {
                Transform boneTransform = _physicalAnimator.GetBoneTransform(bone);
                if (
                    boneTransform != null
                    && (boneTransform.TryGetComponent(out ConfigurableJoint joint))
                )
                    jointList.Add(joint);
            }

            return jointList;
        }

        private void FixedUpdate()
        {
            // SyncAnimatedBody();
        }

        /// <summary> 실제 루트와 일치하도록 애니메이션 본체의 루트의 회전 및 위치를 업데이트합니다.</summary>
        private void SyncAnimatedBody()
        {
            // 이것은 IK 움직임이 애니메이션과 물리적 신체 사이에서 동기화되기 위해 필요합니다.
            // 예를 들어 어떤 것을 볼 때, 만약 애니메이션과 물리적 신체가 같은 위치에 있지 않고 같은 방향을 가진다면,
            // IK가 애니메이션 신체에 대해 계산한 머리 움직임은 물리적 신체가 같은 것을 볼 필요가 있는 움직임과 다를 것이므로,
            // 그들은 완전히 다른 장소를 볼 것입니다.
            if (SyncTorsoPositions)
                _animatedAnimator.transform.position =
                    _physicalTorso.position
                    + (_animatedAnimator.transform.position - _animatedTorso.position);
            if (SyncTorsoRotations)
                _animatedAnimator.transform.rotation = _physicalTorso.rotation;
        }

        // ------------------- GETTERS & SETTERS -------------------

        /// <summary> 주어진 ANIMATIVE BODY'S BONE의 transfrom을 가져옵니다 </summary>
        /// <param name="bone">Bone you want the transform of</param>
        /// <returns>The transform of the given ANIMATED bone</returns>
        public Transform GetAnimatedBone(HumanBodyBones bone)
        {
            return _animatedAnimator.GetBoneTransform(bone);
        }

        /// <summary> 주어진 PHYSICAL BODY'S BONE의 transfrom을 가져옵니다 </summary>
        /// <param name="bone">Bone you want the transform of</param>
        /// <returns>The transform of the given PHYSICAL bone</returns>
        public Transform GetPhysicalBone(HumanBodyBones bone)
        {
            return _physicalAnimator.GetBoneTransform(bone);
        }

        public BodyPart GetBodyPart(string name)
        {
            foreach (BodyPart bodyPart in _bodyParts)
                if (bodyPart.bodyPartName == name)
                    return bodyPart;

            return null;
        }

        public void SetStrengthScaleForAllBodyParts(float scale)
        {
            foreach (BodyPart bodyPart in _bodyParts)
                bodyPart.SetStrengthScale(scale);
        }
    }
} // namespace ActiveRagdoll

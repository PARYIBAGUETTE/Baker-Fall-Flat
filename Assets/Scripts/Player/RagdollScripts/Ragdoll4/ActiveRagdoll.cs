using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveRagdoll : MonoBehaviour
{
    [Header("--- ANIMATORS ---")]
    [SerializeField]
    private Animator _animator;
    public Animator Animator
    {
        get { return _animator; }
        private set { _animator = value; }
    }
}

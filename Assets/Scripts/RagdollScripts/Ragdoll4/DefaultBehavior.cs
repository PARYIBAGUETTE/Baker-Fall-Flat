using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBehavior : MonoBehaviour
{
    [Header("Modules")]
    [SerializeField]
    private ActiveRagdoll _activeRagdoll;

    [SerializeField]
    private AnimatorModule _animatorModule;

    private void OnValidate()
    {
        if (_activeRagdoll == null)
        {
            _activeRagdoll = GetComponent<ActiveRagdoll>();
        }
        if (_animatorModule == null)
        {
            _animatorModule = GetComponent<AnimatorModule>();
        }
    }
}

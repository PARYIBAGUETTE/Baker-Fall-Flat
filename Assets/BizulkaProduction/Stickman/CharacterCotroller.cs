using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CharacterCotroller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private ConfigurableJoint hipjoint;

    [SerializeField] private Rigidbody hipRigid;
    [SerializeField] private Animator animator;


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3 (horizontal, 0, vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            Debug.Log(dir.magnitude);
            animator.SetBool("isWalking",true);
            hipRigid.AddForce(dir * speed);
        }
        else
        {
            animator.SetBool("isWalking", false);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            hipRigid.AddForce(Vector3.up * 500);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Transform leftHandTarget;

    [SerializeField]
    private Transform rightHandTarget;

    [SerializeField]
    private Transform defaultLeftHandTarget;

    [SerializeField]
    private Transform defaultRightHandTarget;

    [SerializeField]
    private Transform aimLeftHandTarget;

    [SerializeField]
    private Transform aimRightHandTarget;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float jumpForce = 1f;

    public bool isGround = true;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        leftHandTarget = GetComponent<Transform>();
        rightHandTarget = GetComponent<Transform>();
        defaultLeftHandTarget = GetComponent<Transform>();
        defaultRightHandTarget = GetComponent<Transform>();
        aimLeftHandTarget = GetComponent<Transform>();
        aimRightHandTarget = GetComponent<Transform>();

        leftHandTarget.position = defaultLeftHandTarget.position;
        rightHandTarget.position = defaultRightHandTarget.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float multiplier = 1f;

        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (_rigidbody.velocity.magnitude < speed * multiplier)
        {
            float value = Input.GetAxis("Vertical");
            if (value != 0)
                _rigidbody.AddForce(0, 0, value * Time.fixedDeltaTime * 1000f);
            value = Input.GetAxis("Horizontal");
            if (value != 0)
                _rigidbody.AddForce(value * Time.fixedDeltaTime * 1000f, 0f, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            leftHandTarget.localPosition = Vector3.Slerp(
                defaultLeftHandTarget.localPosition,
                aimLeftHandTarget.localPosition,
                0.5f
            );
            Debug.Log("왼손!");
        }
        else
        {
            leftHandTarget.localPosition = defaultLeftHandTarget.localPosition;
        }
        if (Input.GetMouseButtonDown(1))
        {
            rightHandTarget.localPosition = Vector3.Slerp(
                defaultRightHandTarget.localPosition,
                aimRightHandTarget.localPosition,
                0.5f
            );
            Debug.Log("오른손!");
        }
        else
        {
            rightHandTarget.localPosition = defaultRightHandTarget.localPosition;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isGround = true;
    }
}

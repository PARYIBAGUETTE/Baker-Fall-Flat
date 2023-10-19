using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefaultBehavior : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerActions playerAction;

    public PlayerInputAction PlayerInputAction
    {
        get { return playerInputAction; }
        private set { playerInputAction = value; }
    }
    public PlayerInputAction.PlayerActions PlayerAction
    {
        get { return playerAction; }
        private set { playerAction = value; }
    }

    [Header("Modules")]
    [SerializeField]
    private ActiveRagdoll _activeRagdoll;

    [SerializeField]
    private AnimatorModule _animatorModule;

    [SerializeField]
    private CharacterController _controller;

    [SerializeField]
    private float moveSpeed = 5.0f; // << 여기 둘다 안쓰는 건데 확인 해주세요!
    private Vector3 moveDirection; // <<<

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Vector3 moveDir;

    [SerializeField]
    private Vector3 forwardDir;

    [Header("Climb Stairs")]
    [SerializeField]
    private GameObject stepRayUpper;

    [SerializeField]
    private GameObject stepRayLower;

    [SerializeField]
    private float stepHeight = 0.3f;

    [SerializeField]
    private float stepSmooth = 0.1f;

    public bool IsGround = false;

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



    private void Start()
    {
        // 임시 플레이어 인풋
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 잠금

        playerAction.Move.started += GetMoveMentDir;
        playerAction.Move.performed += GetMoveMentDir;
        playerAction.Move.canceled += GetMoveMentDir;
    }

    private void FixedUpdate()
    {
        LookCameraDir();
        SetDirFromCamera();
        MovePlayer();

        //임시
        if (Input.GetKey(KeyCode.Space))
        {
            _activeRagdoll.PhysicalTorso.AddForce(Vector3.up * 300);
        }
    }

    // Move 입력시 호출
    public void GetMoveMentDir(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        moveDir.z = moveDir.y;
        moveDir.y = 0;
        moveDir.Normalize();

        if (moveDir == Vector3.zero)
        {
            _activeRagdoll.AnimatedAnimator.SetBool("isForward", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isBackward", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isRightSide", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isLeftSide", false);
            return;
        }
        else if (moveDir.z > 0)
        {
            _activeRagdoll.AnimatedAnimator.SetBool("isForward", true);
            _activeRagdoll.AnimatedAnimator.SetBool("isRightSide", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isLeftSide", false);
        }
        else if (moveDir.x == +1)
        {
            _activeRagdoll.AnimatedAnimator.SetBool("isRightSide", true);
            _activeRagdoll.AnimatedAnimator.SetBool("isForward", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isBackward", false);
        }
        else if (moveDir.x == -1)
        {
            _activeRagdoll.AnimatedAnimator.SetBool("isLeftSide", true);
            _activeRagdoll.AnimatedAnimator.SetBool("isForward", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isBackward", false);
        }
        else if (moveDir.z < 0)
        {
            _activeRagdoll.AnimatedAnimator.SetBool("isBackward", true);
            _activeRagdoll.AnimatedAnimator.SetBool("isRightSide", false);
            _activeRagdoll.AnimatedAnimator.SetBool("isLeftSide", false);
        }
    }

    public void SetDirFromCamera()
    {
        Vector3 forword = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forword.y = 0;
        right.y = 0;
        forword.Normalize();
        right.Normalize();

        forwardDir = (forword * moveDir.z + right * moveDir.x).normalized;
    }

    private void LookCameraDir()
    {
        Vector3 temp = camera.transform.position - _activeRagdoll.AnimatedTorso.transform.position;
        temp.y = 0;
        Quaternion dir = Quaternion.LookRotation(temp);
        _activeRagdoll.AnimatedTorso.transform.rotation = dir;
        _activeRagdoll.AnimatedTorso.transform.Rotate(Vector3.up * 90);
    }

    public void MovePlayer() 
    {
        _controller.Move(forwardDir * Time.fixedDeltaTime * speed);
    }
}

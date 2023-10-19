using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefaultBehavior : MonoBehaviour
{
    [Header("---Camera---")]
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

    [Header("---Module---")]
    [SerializeField]
    private ActiveRagdoll _activeRagdoll;
    public ActiveRagdoll ActiveRagdoll
    {
        get { return _activeRagdoll; }
        private set { _activeRagdoll = value; }
    }

    [SerializeField]
    private AnimatorModule _animatorModule;

    [SerializeField]
    private MovementModule _movementModule;

    [SerializeField]
    private CharacterController _characterController;
    public CharacterController CharacterController
    {
        get { return _characterController; }
        private set { _characterController = value; }
    }

    [SerializeField]
    private ArmsController _armsController;

    [Header("---Value---")]
    [SerializeField]
    private Vector3 moveDir;

    [SerializeField]
    private Vector3 forwardDir;

    public bool isGround = false;

    // 인스펙터 컴포넌트 할당
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
        if (_movementModule == null)
        {
            _movementModule = GetComponent<MovementModule>();
        }
        if (_armsController == null)
        {
            _armsController = GetComponent<ArmsController>();
        }
    }

    private void Awake()
    {
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 잠금

        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _armsController.Init(this);
    }

    private void OnEnable()
    {
        playerAction.Move.started += GetMoveMentDir;
        playerAction.Move.performed += GetMoveMentDir;
        playerAction.Move.canceled += GetMoveMentDir;
    }

    private void OnDisable()
    {
        playerAction.Move.started -= GetMoveMentDir;
        playerAction.Move.performed -= GetMoveMentDir;
        playerAction.Move.canceled -= GetMoveMentDir;
    }

    private void FixedUpdate()
    {
        LookCameraDir();
        SetDirFromCamera();
        _movementModule.MoveTo(forwardDir);

        //임시
        if (Input.GetKey(KeyCode.Space))
        {
            _movementModule.JumpTo();
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
}

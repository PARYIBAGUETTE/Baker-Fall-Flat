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

    [SerializeField]
    private CharacterController _characterController;
    public CharacterController CharacterController
    {
        get { return _characterController; }
        private set { _characterController = value; }
    }

    [SerializeField]
    private ArmsController _armsController;

    [SerializeField]
    private Animator _animator;
    public Animator Animator
    {
        get { return _animator; }
        private set { _animator = value; }
    }

    [Header("---Value---")]
    [SerializeField]
    private Vector3 moveDir;

    [SerializeField]
    private Vector3 forwardDir;

    // 인스펙터 컴포넌트 할당
    private void OnValidate()
    {
        if (_armsController == null)
        {
            _armsController = GetComponent<ArmsController>();
        }
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }
    }

    private void Awake()
    {
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        Cursor.lockState = CursorLockMode.Locked;
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

        // playerAction.Option.started += TurnOption;
    }

    private void OnDisable()
    {
        playerAction.Move.started -= GetMoveMentDir;
        playerAction.Move.performed -= GetMoveMentDir;
        playerAction.Move.canceled -= GetMoveMentDir;

        // playerAction.Option.started -= TurnOption;
    }

    private void FixedUpdate()
    {
        // LookCameraDir();
        SetDirFromCamera();
    }

    // Move 입력시 호출
    public void GetMoveMentDir(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        moveDir.z = moveDir.y;
        moveDir.y = 0;
        moveDir.Normalize();
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

    // private void LookCameraDir()
    // {
    //     Vector3 temp = camera.transform.position - transform.position;
    //     temp.y = 0;
    //     Quaternion dir = Quaternion.LookRotation(temp);
    //     transform.rotation = dir;
    //     transform.Rotate(Vector3.up);
    // }

    // private void TurnOption(InputAction.CallbackContext context)
    // {
    //     if (!UIManager.Instance.IsOpenUI<UIMenu>())
    //     {
    //         UIManager.Instance.OpenUI<UIMenu>();
    //         Cursor.lockState = CursorLockMode.None;
    //         Time.timeScale = 0f;
    //     }
    //     else
    //     {
    //         UIManager.Instance.CloseUI<UIMenu>();
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Time.timeScale = 1f;
    //     }

    //     if (UIManager.Instance.IsOpenUI<UIOptionInGame>())
    //     {
    //         UIManager.Instance.CloseUI<UIOptionInGame>();
    //         UIManager.Instance.CloseUI<UIMenu>();
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Time.timeScale = 1f;
    //     }

    //     if (UIManager.Instance.IsOpenUI<UIAudioInGame>())
    //     {
    //         UIManager.Instance.CloseUI<UIAudioInGame>();
    //         UIManager.Instance.CloseUI<UIOptionInGame>();
    //         UIManager.Instance.CloseUI<UIMenu>();
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Time.timeScale = 1f;
    //     }
    // }
}

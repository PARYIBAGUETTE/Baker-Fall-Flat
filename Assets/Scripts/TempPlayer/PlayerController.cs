using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerActions playerAction;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private ArmsController armsController;

    [SerializeField]
    private ConfigurableJoint hipjoint;

    [SerializeField]
    private Rigidbody hipRigid;

    [SerializeField]
    private Animator animator;

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
    public Animator Animator
    {
        get { return animator; }
    }

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

    [SerializeField]
    private CharacterController cont;

    private void Awake()
    {
        // 임시 플레이어 인풋
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 잠금

        playerAction.Move.started += GetMoveMentDir;
        playerAction.Move.performed += GetMoveMentDir;
        playerAction.Move.canceled += GetMoveMentDir;

        playerAction.Option.started += TurnOption;

        stepRayUpper.transform.position = new Vector3(
            stepRayUpper.transform.position.x,
            stepRayLower.transform.position.y + stepHeight,
            stepRayUpper.transform.position.z
        );
    }

    private void Start()
    {
        armsController.Init(this);
        //jumpHandler.Init(this);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        LookCameraDir();
        SetDirFromCamera();
        MovePlayer();

        if (moveDir == Vector3.forward)
        {
            Debug.Log("check");
            StepClimb();
        }

        //임시
        if (Input.GetKey(KeyCode.Space))
        {
            hipRigid.AddForce(Vector3.up * 300);
        }
    }

    private void StepClimb()
    {
        if (
            Physics.Raycast(
                stepRayLower.transform.position,
                transform.TransformDirection(Vector3.forward),
                out RaycastHit hitLower,
                0.1f
            )
        )
        {
            if (
                !Physics.Raycast(
                    stepRayUpper.transform.position,
                    transform.TransformDirection(Vector3.forward),
                    0.2f
                ) && hitLower.collider.CompareTag("Stairs")
            )
            {
                hipRigid.AddForce(new Vector3(0f, stepSmooth, 0f), ForceMode.Impulse);
            }
        }

        if (
            Physics.Raycast(
                stepRayLower.transform.position,
                transform.TransformDirection(1.5f, 0, 1),
                out RaycastHit hitLowerP45,
                0.1f
            )
        )
        {
            if (
                !Physics.Raycast(
                    stepRayUpper.transform.position,
                    transform.TransformDirection(1.5f, 0, 1),
                    0.2f
                ) && hitLowerP45.collider.CompareTag("Stairs")
            )
            {
                hipRigid.AddForce(new Vector3(0f, stepSmooth, 0f), ForceMode.Impulse);
            }
        }

        if (
            Physics.Raycast(
                stepRayLower.transform.position,
                transform.TransformDirection(-1.5f, 0, 1),
                out RaycastHit hitLowerM45,
                0.1f
            )
        )
        {
            if (
                !Physics.Raycast(
                    stepRayUpper.transform.position,
                    transform.TransformDirection(-1.5f, 0, 1),
                    0.2f
                ) && hitLowerM45.collider.CompareTag("Stairs")
            )
            {
                hipRigid.AddForce(new Vector3(0f, stepSmooth, 0f), ForceMode.Impulse);
            }
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
            animator.SetBool("isForward", false);
            animator.SetBool("isBackward", false);
            animator.SetBool("isRightSide", false);
            animator.SetBool("isLeftSide", false);
            return;
        }
        else if (moveDir.z > 0)
        {
            animator.SetBool("isForward", true);
            animator.SetBool("isRightSide", false);
            animator.SetBool("isLeftSide", false);
        }
        else if (moveDir.x == +1)
        {
            animator.SetBool("isRightSide", true);
            animator.SetBool("isForward", false);
            animator.SetBool("isBackward", false);
        }
        else if (moveDir.x == -1)
        {
            animator.SetBool("isLeftSide", true);
            animator.SetBool("isForward", false);
            animator.SetBool("isBackward", false);
        }
        else if (moveDir.z < 0)
        {
            animator.SetBool("isBackward", true);
            animator.SetBool("isRightSide", false);
            animator.SetBool("isLeftSide", false);
        }
    }

    public void SetDirFromCamera()
    {
        Vector3 forword = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forword.y = 0;
        right.y = 0;
        forword.Normalize();
        right.Normalize();
        //Debug.Log(forwardDir);

        forwardDir = forword * cam.transform.position.z + right * cam.transform.position.x;
    }

    private void LookCameraDir()
    {
        Vector3 temp = cam.transform.position - hipjoint.transform.position;
        temp.y = 0;
        Quaternion dir = Quaternion.LookRotation(temp);
        hipjoint.transform.rotation = dir;
        hipjoint.transform.Rotate(Vector3.up * 90);
    }

    public void MovePlayer()
    {
        //hipRigid.AddForce(Vector3.up * 40);
        cont.Move(speed * Time.fixedDeltaTime * moveDir);
    }

    private void TurnOption(InputAction.CallbackContext context)
    {
        if (!UIManager.Instance.IsOpenUI<UIOption>())
        {
            UIManager.Instance.OpenUI<UIOption>();
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            UIManager.Instance.CloseUI<UIOption>();
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

        if (UIManager.Instance.IsOpenUI<UIAudio>())
        {
            UIManager.Instance.CloseUI<UIAudio>();
            UIManager.Instance.CloseUI<UIOption>();
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}

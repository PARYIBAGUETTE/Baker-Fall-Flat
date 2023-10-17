
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerActions playerAction;

    [SerializeField] private Camera cam;
    [SerializeField] private ArmsController armsController;
    [SerializeField] private ConfigurableJoint hipjoint;
    [SerializeField] private Rigidbody hipRigid;
    [SerializeField] private Animator animator;

    public PlayerInputAction PlayerInputAction { get { return playerInputAction; } private set { playerInputAction = value; } }
    public PlayerInputAction.PlayerActions PlayerAction { get { return playerAction; } private set { playerAction = value; } }
    public Animator Animator { get { return animator; } }

    [SerializeField] private float speed = 10;
    [SerializeField] private Vector3 moveDir;
    [SerializeField] private Vector3 forwardDir;


    private void Awake()
    {
        // 임시 플레이어 인풋
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 잠금
        //

        playerAction.Move.started += GetMoveMentDir;
        playerAction.Move.performed += GetMoveMentDir;
        playerAction.Move.canceled += GetMoveMentDir;
    }


    private void Start()
    {
        armsController.Init(this);
    }


    private void FixedUpdate()
    {
        SetDirFromCamera();
        LookCameraDir();
        MovePlayer();

        //임시
        if (Input.GetKey(KeyCode.Space))
        {
            hipRigid.AddForce(Vector3.up * 300);
        }
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
        Vector3 forword = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forword.y = 0;
        right.y = 0;
        forword.Normalize();
        right.Normalize();

        forwardDir = forword * moveDir.z + right * moveDir.x;
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
        if (moveDir == Vector3.zero)
        {
            animator.SetBool("isForward", false);
            animator.SetBool("isBackward", false);
            animator.SetBool("isRightSide", false);
            animator.SetBool("isLeftSide", false);
            return;
        }
        else if (moveDir.z > 0)
            animator.SetBool("isForward", true);
        else if (moveDir.x == +1)
            animator.SetBool("isRightSide", true);
        else if (moveDir.x == -1)
            animator.SetBool("isLeftSide", true);
        else if (moveDir.z < 0)
            animator.SetBool("isBackward", true);

        hipRigid.AddForce(Vector3.up * 30);
        hipRigid.AddForce(forwardDir * speed);
    }
}

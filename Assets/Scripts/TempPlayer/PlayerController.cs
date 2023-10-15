
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerActions playerAction;

    [SerializeField] private ArmsController armsController;
    [SerializeField] private ConfigurableJoint hipjoint;
    [SerializeField] private Rigidbody hipRigid;
    [SerializeField] private Animator animator;

    [SerializeField] private float speed = 4f;

    public PlayerInputAction PlayerInputAction { get { return playerInputAction; } private set { playerInputAction = value; } }
    public PlayerInputAction.PlayerActions PlayerAction { get { return playerAction; } private set { playerAction = value; } }
    public Animator Animator { get { return animator; } }


    private void Awake()
    {
        // 임시 플레이어 인풋
        PlayerInputAction = new PlayerInputAction();
        PlayerAction = PlayerInputAction.Player;
        PlayerAction.Enable();
        //
    }

    private void Start()
    {
        armsController.Init(this);
    }


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;


        if (dir.magnitude < 0.1f)
        {
            animator.SetBool("isFrontWalking", false);
            animator.SetBool("isForwardWarking", false);
        }
        else if (dir.z >= 0)
        {
            animator.SetBool("isFrontWalking", true);
            animator.SetBool("isForwardWarking", false);
            if (hipRigid.velocity.magnitude < 6)
            {
                hipRigid.AddForce(dir * speed);
            }
        }
        else if (dir.z < 0)
        {
            animator.SetBool("isFrontWalking", false);
            animator.SetBool("isForwardWarking", true);
            if (hipRigid.velocity.magnitude < 6)
            {
                hipRigid.AddForce(dir * speed);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            hipRigid.AddForce(Vector3.up * 200);
        }
    }
}

using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Camera Switch Script")]
    private CameraSwitch cameraSwitch;

    [Header("Movement Properties")]
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public float gravity = -9.8f;
    public bool isGrounded;

    private Rigidbody rb;

    [Header("Animation")]
    private Animator anim;

    [Header("Push Mechanic")]
    private PushMechanic pushMechanic;
    private bool isPushing = false;

    private void Start()
    {
        cameraSwitch = FindFirstObjectByType<CameraSwitch>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pushMechanic = GetComponent<PushMechanic>();

        GameManager.instance.StartGame();
    }
    private void Update()
    {
        if (!cameraSwitch.isTransitioning && GameManager.instance.gameState == GameState.GameStart)
        {
            if (cameraSwitch.is2D)
            {
                MoveTwoD();
            }
            else
            {
                MoveIso();
            }  
        }      
    }

    void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }

    void MoveTwoD()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(horizontal, 0, 0);

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        if (move.magnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            if (isGrounded)
            {
                anim.SetInteger("AnimState", 1);
            }
        }

        if (move.magnitude == 0)
        {
            if (isGrounded)
            {
                anim.SetInteger("AnimState", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // Jumping
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            anim.SetTrigger("JumpAnim");
            isGrounded = false;
        }
    }

    void MoveIso()
    {
        if (!isPushing)
        {
            float vertical = Input.GetAxisRaw("Horizontal");

            Vector3 move = new Vector3(0, 0, -vertical);

            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if (move.magnitude > 0)
            {
                Quaternion rotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

                if (isGrounded)
                {
                    anim.SetInteger("AnimState", 1);
                }
            }

            if (move.magnitude == 0)
            {
                if (isGrounded)
                {
                    anim.SetInteger("AnimState", 0);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isPushing == false) //Pushing
        {
            anim.SetInteger("AnimState", 2);
            isPushing = true;
            Invoke("IsPushingTrue", 1);
        }
    }

    void IsPushingTrue()
    {
        isPushing = false;
    }
}

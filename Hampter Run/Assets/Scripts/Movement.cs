using UnityEngine;
using UnityEngine.Timeline;

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

    [Header("Animation Manager")]
    private AnimationManager animator;

    [Header("Push Mechanic")]
    private PushMechanic pushMechanic;
    private bool isPushing = false;

    private void Start()
    {
        cameraSwitch = FindFirstObjectByType<CameraSwitch>();
        rb = GetComponent<Rigidbody>();
        pushMechanic = GetComponentInChildren<PushMechanic>();
        animator = GetComponent<AnimationManager>();

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
            animator.Falling();
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
                animator.Move();
            }
        }

        if (move.magnitude == 0)
        {
            if (isGrounded)
            {
                animator.Idle();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // Jumping
        {
            animator.Jumping();
        }
    }

    public void JumpForce()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        isGrounded = false;
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
                    animator.Move();
                }
            }

            if (move.magnitude == 0)
            {
                if (isGrounded)
                {
                    animator.Idle();
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isPushing == false) //Pushing
        {
            pushMechanic.RaycastPush();
            isPushing = true;
            Invoke("IsPushingTrue", 1);
        }
    }

    void IsPushingTrue()
    {
        isPushing = false;
    }
}

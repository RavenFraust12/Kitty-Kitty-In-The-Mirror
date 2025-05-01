using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Camera Switch Script")]
    public CameraSwitch cameraSwitch;

    [Header("Movement Properties")]
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public float gravity = -9.8f;
    public bool isGrounded;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

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
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void MoveIso()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(0, 0, -vertical);

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        if (move.magnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}

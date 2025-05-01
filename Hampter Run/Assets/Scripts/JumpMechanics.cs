using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    private Movement movement;

    private void Awake()
    {
        movement = GetComponentInParent<Movement>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movement.isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movement.isGrounded = false;
        }
    }
}

using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    private Movement movement;
    private int groundContacts;

    private void Awake()
    {
        movement = GetComponentInParent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts++;
            movement.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts--;
            movement.isGrounded = groundContacts > 0;
        }
    }
}

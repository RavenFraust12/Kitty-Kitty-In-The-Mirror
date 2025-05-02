using UnityEngine;

public class MoveObject : MonoBehaviour, IPushable
{
    public float pushForce = 5f;

    private Rigidbody rb;
    private Movement player;

    void Start()
    {
        player = FindFirstObjectByType<Movement>();
        rb = GetComponent<Rigidbody>();
    }

    public void PushInteraction()
    {
        if (player == null || rb == null) return;

        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        Vector3 pushDirection = (transform.position - player.transform.position).normalized;

        rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);

        Invoke("EnableRigidBodyConstraints", .5f);
    }

    public void EnableRigidBodyConstraints()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

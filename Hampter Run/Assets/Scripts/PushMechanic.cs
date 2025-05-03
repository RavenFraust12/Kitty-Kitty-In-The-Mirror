using UnityEngine;

public class PushMechanic : MonoBehaviour
{
    public float rayDistance = 2f;
    public LayerMask pushableLayer; // Make sure to assign this in the inspector
    private AnimationManager animator;
    private void Start()
    {
        animator = GetComponentInParent<AnimationManager>();
    }

    public void RaycastPush()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, pushableLayer))
        {
            IPushable itemPushable = hit.collider.GetComponent<IPushable>();
            if (itemPushable != null)
            {
                animator.Pushing();
                Debug.Log("Object Detected");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IPushable itemPushable = other.GetComponent<IPushable>();
        if (itemPushable != null)
        {
            itemPushable.PushInteraction();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }

}

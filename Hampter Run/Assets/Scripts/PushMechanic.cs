using UnityEngine;

public class PushMechanic : MonoBehaviour
{
    public BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        IPushable itemPushable = other.GetComponent<IPushable>();

        if (itemPushable != null)
        {
            itemPushable.PushInteraction();
        }
    }
}

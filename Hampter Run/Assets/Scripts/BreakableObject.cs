using UnityEngine;

public class BreakableObject : MonoBehaviour, IPushable
{
    private Animator anim;
    private bool isInteracted = false;
    public GameObject destroyedObject;
    public GameObject currentObject;
    private Movement player;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = FindFirstObjectByType<Movement>();
    }
    public void PushInteraction()
    {
        if (!isInteracted)
        {
            Vector3 direction = (transform.position - player.transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);

            isInteracted = true;
            anim.SetTrigger("Break");
            Invoke("Destroying", 1f);
        }
    }

    void Destroying()
    {
        MeshRenderer meshRenderer = currentObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        destroyedObject.SetActive(true);
        Destroy(transform.gameObject, 0.5f);
    }
}

using UnityEngine;

public class BreakableObject : MonoBehaviour, IPushable
{
    private Animator anim;
    private bool isInteracted = false;
    public GameObject destroyedObject;
    private Movement player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindFirstObjectByType<Movement>();
    }
    public void PushInteraction()
    {
        if (!isInteracted)
        {
            transform.LookAt(player.transform.position);

            isInteracted = true;
            anim.SetTrigger("Break");
            Invoke("Destroying", 0.5f);
        }
    }

    void Destroying()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        destroyedObject.SetActive(true);
        Destroy(transform.parent.gameObject, 0.5f);
    }
}

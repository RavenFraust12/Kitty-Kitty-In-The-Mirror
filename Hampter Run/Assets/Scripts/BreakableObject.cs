using UnityEngine;

public class BreakableObject : MonoBehaviour, IPushable
{
    private Animator anim;
    private bool isInteracted = false;
    public GameObject particleSmoke;
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
        }
    }

    public void Destroying()
    {
        Vector3 offset = new Vector3(0, 0, 3);
        GameObject Particle = Instantiate(particleSmoke, transform.position, Quaternion.identity);
        AudioManager.instance.BreakVase();

        Destroy(Particle,1.5f);
        Destroy(transform.gameObject);
    }
}

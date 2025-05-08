using UnityEngine;

public class StarPoints : MonoBehaviour
{
    private StarRequirement starRequirement;
    public ParticleSystem starParticle;
    public SphereCollider sphereCollider;
    public MeshRenderer starRenderer;

    private bool hasTriggered = false;

    private void Start()
    {
        starRequirement = FindFirstObjectByType<StarRequirement>();
        sphereCollider = GetComponent<SphereCollider>();
        starRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (hasTriggered) return; // prevent double trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // Hide the mesh + disable collider
            starRenderer.enabled = false;
            sphereCollider.enabled = false;
            hasTriggered = true;

            // Logic
            starRequirement.starsAcquired++;
            starRequirement.DelayShow(starRequirement.starsObject, starRequirement.starsAcquired - 1);
            AudioManager.instance.CollectStar();



            // Play particle and wait
            if (starParticle != null)
            {
                starParticle.Play();
                StartCoroutine(WaitForParticles());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator WaitForParticles()
    {
        // Wait until the particle system is done
        while (starParticle.IsAlive(true))
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}

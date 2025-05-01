using UnityEngine;

public class StarPoints : MonoBehaviour
{
    private StarRequirement starRequirement;

    private void Start()
    {
        starRequirement = FindFirstObjectByType<StarRequirement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            starRequirement.starsAcquired++;
            starRequirement.DelayShow(starRequirement.starsObject, starRequirement.starsAcquired - 1);
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            Destroy(gameObject);
        }
    }
}

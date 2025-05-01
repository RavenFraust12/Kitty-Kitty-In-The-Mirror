using UnityEngine;

public class StarManager : MonoBehaviour
{
    public StarRequirement[] starRequirements;

    private void Start()
    {
        for(int i = 0; i < starRequirements.Length; i++)
        {
            starRequirements[i].ShowAcquiredStars();
        }
    }
}

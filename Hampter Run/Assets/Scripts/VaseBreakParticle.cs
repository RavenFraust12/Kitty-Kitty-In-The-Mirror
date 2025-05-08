using UnityEngine;

public class VaseBreakParticle : MonoBehaviour
{
    public BreakableObject breakableObject;
    void Start()
    {
        breakableObject = GetComponentInParent<BreakableObject>();
    }
    public void Break()
    {
        breakableObject.Destroying();
    }
}

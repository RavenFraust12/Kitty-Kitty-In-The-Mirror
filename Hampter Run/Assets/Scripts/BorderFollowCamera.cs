using UnityEngine;

public class BorderFollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector2 followBounds = new Vector2(2f, 2f); // Deadzone width & height
    public float followSpeed = 5f;

    public bool isIsometric = false;

    private Vector3 offset;

    void Start()
    {
        // Optional offset so the camera doesn’t start directly on the player
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position;

        // Get player position in camera-local space
        Vector3 playerLocal = transform.InverseTransformPoint(player.position);

        // X-axis check
        if (Mathf.Abs(playerLocal.x) > followBounds.x)
        {
            float dir = Mathf.Sign(playerLocal.x);
            targetPosition += transform.right * (playerLocal.x - (followBounds.x * dir));
        }

        // Y-axis check
        if (Mathf.Abs(playerLocal.y) > followBounds.y)
        {
            float dir = Mathf.Sign(playerLocal.y);
            targetPosition += transform.up * (playerLocal.y - (followBounds.y * dir));
        }

        // Smoothly move camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 twoDPosition = new Vector3(0, 0, 10);
    public Vector3 isoPosition = new Vector3(10, 10, -10);
    public Quaternion twoDRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion isoRotation = Quaternion.Euler(30, 45, 0);
    public float twoDSize = 5f;
    public float isoSize = 10f;
    public float transitionDuration = 1f;

    public bool is2D = true;
    public bool isTransitioning = false;
    private float transitionProgress = 0f;

    private Vector3 startPos;
    private Quaternion startRot;
    private float startSize;

    private Vector3 targetPos;
    private Quaternion targetRot;
    private float targetSize;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isTransitioning)
        {
            StartTransition();
        }

        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime / transitionDuration;

            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, transitionProgress);
            mainCamera.transform.rotation = Quaternion.Lerp(startRot, targetRot, transitionProgress);
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, transitionProgress);

            if (transitionProgress >= 1f)
            {
                isTransitioning = false;
                transitionProgress = 0f;
                is2D = !is2D;
            }
        }
    }

    void StartTransition()
    {
        isTransitioning = true;
        transitionProgress = 0f;

        startPos = mainCamera.transform.position;
        startRot = mainCamera.transform.rotation;
        startSize = mainCamera.orthographicSize;

        if (is2D)
        {
            targetPos = isoPosition;
            targetRot = isoRotation;
            targetSize = isoSize;
        }
        else
        {
            targetPos = twoDPosition;
            targetRot = twoDRotation;
            targetSize = twoDSize;
        }
    }
}

using UnityEngine;

public class ConstantSizeCanvas : MonoBehaviour
{
    private Camera mainCamera;
    private float initialDistance;

    void Start()
    {
        mainCamera = Camera.main; // Automatically assigns the main camera
        if (mainCamera == null)
        {
            Debug.LogError("No camera tagged as 'MainCamera' found.");
        }
        initialDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        transform.localScale = Vector3.one * (currentDistance / initialDistance);
    }
}
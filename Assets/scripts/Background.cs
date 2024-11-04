using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraTransform.position + offset;
    }
}

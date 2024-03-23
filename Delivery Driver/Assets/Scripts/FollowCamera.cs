using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCarTransform;

    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = new Vector3(0, 0, -10);
    }

    private void LateUpdate()
    {
        transform.position = playerCarTransform.position + cameraOffset;
    }
}

using UnityEngine;

public class WallCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, cameraTransform.position.y, transform.position.z);
    }
}

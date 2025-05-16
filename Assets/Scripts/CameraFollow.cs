using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float screenHeight = 10f;
    
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            if (player.position.y > transform.position.y + (screenHeight / 2f))
            {   
                targetPosition += new Vector3(0f, screenHeight, 0f);
            }

            if (player.position.y < transform.position.y - (screenHeight / 2f))
            {
                targetPosition -= new Vector3(0f, screenHeight, 0f);
            }
            
            transform.position = targetPosition;
        }
    }
}

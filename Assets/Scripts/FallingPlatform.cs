using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb2d; 
    public float fallDelay = 0.5f; 
    public PointEffector2D pointEffector; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pointEffector = GetComponent<PointEffector2D>();

        rb2d.isKinematic = true; 
        pointEffector.enabled = false; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Invoke("DropPlatform", fallDelay); 
        }
    }

    void DropPlatform()
    {
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 3f);
    }


}

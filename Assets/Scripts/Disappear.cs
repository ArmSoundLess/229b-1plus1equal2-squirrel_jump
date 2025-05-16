using System;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 10f;

    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    private void OnInit()
    {
        rb.velocity = transform.right * speed;
        Invoke(nameof(OnDespawn), 4f);
    }
    private void OnDespawn()
    {
        Destroy(gameObject);
    }
}

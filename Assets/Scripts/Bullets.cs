using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed ;
    }

    void Update()
    {
        DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            // Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        if(collider.CompareTag("Enemy1"))
        {
            // Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        else if(collider.gameObject.CompareTag("Terrain") || collider.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }

    
    public void DestroyBullet()
    {
        if(transform.position.x > playerT.position.x + 12 || transform.position.x < playerT.position.x - 12)
        {
            Destroy(gameObject);
        }
    }

}

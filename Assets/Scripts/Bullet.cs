using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D rb;


   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.right = mousePos - transform.position; 
        rb.velocity = transform.right * Speed;
    }

  
    void Update()
    {
    
    }

    // Detectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
            Destroy(gameObject);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            Destroy(gameObject);

    }
        
}


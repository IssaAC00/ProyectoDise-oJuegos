using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.right = mousePos - transform.position; // Orienta la bala hacia la posici�n del mouse.
        rb.velocity = transform.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Agrega cualquier l�gica adicional aqu� si es necesario.
    }

    // Detectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}


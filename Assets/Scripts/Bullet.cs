using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Rigidbody2D MyRb;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = transform.right * Time.deltaTime * Speed;
        Destroy(gameObject, 7f);
    }

    // Detectar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2D : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float patrolDistance = 2f; 
    public float changeDirectionInterval = 5f; 
    private float initialPositionX; 
    private int moveDirection = 1; 
    private float timeSinceDirectionChange = 0f; 
    public int damageAmount = 10; 


    private void Start()
    {
        initialPositionX = transform.position.x; 
        timeSinceDirectionChange = Random.Range(0f, changeDirectionInterval); 
    }

    private void Update()
    {
        timeSinceDirectionChange += Time.deltaTime;
        if (timeSinceDirectionChange >= changeDirectionInterval)
        {
            ChangeDirectionRandomly();
            timeSinceDirectionChange = 0f; 
        }
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);
        float distanceMoved = Mathf.Abs(transform.position.x - initialPositionX);
        if (distanceMoved >= patrolDistance)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        moveDirection *= -1;
    }

    private void ChangeDirectionRandomly()
    {
        moveDirection = Random.Range(0, 2) == 0 ? -1 : 1;
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Causa da�o al jugador.
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }*/
}

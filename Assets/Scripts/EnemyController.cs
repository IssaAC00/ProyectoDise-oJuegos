using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject platformPrefab; 
    private int bulletHits = 0; 
    private bool isAlive = true; 
    public void BulletHit()
    {
        if (isAlive)
        {
            bulletHits++; 
            if (bulletHits >= 3)
            {
                GeneratePlatform(); 
                Destroy(gameObject); 
                isAlive = false; 
            }
        }
    }

    private void GeneratePlatform()
    {
        Vector3 platformPosition = transform.position + new Vector3(0, 2, 0);
        Instantiate(platformPrefab, platformPosition, Quaternion.identity);
    }
}

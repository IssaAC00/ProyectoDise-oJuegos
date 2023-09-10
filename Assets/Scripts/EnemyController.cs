using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject platformPrefab; 
    private int bulletHits = 0; 
    private bool isDestroyed = false; 
    public void BulletHit()
    {
        if (!isDestroyed)
        {
            bulletHits++; 
            if (bulletHits >= 3)
            {
                GeneratePlatform(); 
                Destroy(gameObject); 
                isDestroyed = true; 
            }
        }
    }

    private void GeneratePlatform()
    {
        Vector3 platformPosition = transform.position + new Vector3(0, 2, 0);
        Instantiate(platformPrefab, platformPosition, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreackWall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    private int bulletHits = 0;
    private bool isAlive = true;
    public void BulletHit()
    {
        if (isAlive)
        {
            bulletHits++;
            if (bulletHits >= 4)
            {
               
                Destroy(gameObject);
                isAlive = false;
            }
        }
    }
}

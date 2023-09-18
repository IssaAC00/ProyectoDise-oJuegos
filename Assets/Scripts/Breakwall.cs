using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakwall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wall;
    private int bulletHits = 0;

    public void BulletHit()
    {

        bulletHits++;
        if (bulletHits >= 4)
            Destroy(gameObject);

    }
}

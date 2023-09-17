using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public int collectibleCount;

    public void AddCollectible()
    {
        collectibleCount++;
    }
}

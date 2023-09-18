using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broke : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakingwall")) { 
        
        Destroy(other.gameObject);
        
        }
    }
}

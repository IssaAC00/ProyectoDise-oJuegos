using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
  private Rigidbody2D rb;
  // Start is called before the first frame update
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    /*
    for (int i = 0; i < collision.gameObject.transform.childCount; i++)
    {
      Transform colChild = collision.gameObject.transform.GetChild(i);
      if (colChild.CompareTag("Wall"))
      {
        Debug.Log("Muro encontrado!");
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        break;
      }
    }
    */
    
    if(collision.gameObject.CompareTag("Wall"))
    {
      Debug.Log("Muro encontrado!");
      rb.velocity = Vector2.zero;
      rb.bodyType = RigidbodyType2D.Static;
      gameObject.layer = 3;
    }
    
  }

}

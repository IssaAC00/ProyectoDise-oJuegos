using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
  private SpriteRenderer spriterend;
  [SerializeField] private Sprite crystal;
  [SerializeField] private Sprite bug;
  [SerializeField] private Sprite plant;
  
  private void Awake()
  {
    spriterend = GetComponent<SpriteRenderer>();
    // Crea un numero aleatorio para determinar que sprite utilizar
    System.Random random = new System.Random();
    int spriteType = random.Next(1,4);
    
    // Aplica el sprite segun el numero aleatorio
    switch (spriteType)
    {
      case 1:
        spriterend.sprite = crystal;
        break;
      
      case 2:
        spriterend.sprite = bug;
        break;

      case 3:
        spriterend.sprite = plant;
        break;
    }
    
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      collision.GetComponent<CollectibleController>().AddCollectible();
      Destroy(gameObject);
    }
  }
}

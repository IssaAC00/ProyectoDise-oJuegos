using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScrapModel : MonoBehaviour
{
  private BoxCollider2D bc;
  private Rigidbody2D rb;

  void Awake()
  {
    bc = GetComponent<BoxCollider2D>();
    rb = GetComponent<Rigidbody2D>();
  }
  
  public void ComponentStatus(bool status)
  {
    bc.enabled = status;
    rb.simulated = status;
  }
}

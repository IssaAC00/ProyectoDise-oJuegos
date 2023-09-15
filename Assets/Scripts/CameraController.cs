using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField]
  private Transform player;

  private float alturaMax = 37.4f;

  private float camOffset = 5f;
  
  // Update is called once per frame
  void Update()
  {
    float bloqueCamara = player.position.y + camOffset;
    if (bloqueCamara > alturaMax)
    {
      transform.position = new Vector3(transform.position.x, alturaMax, transform.position.z);
    }
    else
    {
      transform.position = new Vector3(transform.position.x, bloqueCamara, transform.position.z );
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PickThrow : MonoBehaviour
{
  private GameObject scrapObj;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (scrapObj == null)
      {
        DetectAndPickUp();
      }
    }
    
    if (Input.GetButtonDown("Fire1") && scrapObj != null)
    {
      scrapObj = null;
    }
  }

  void DetectAndPickUp()
  {
    Collider2D[] nearColiders = Physics2D.OverlapCircleAll(transform.position, 0.8f);
    foreach (Collider2D collider in nearColiders)
    {
      if (collider.CompareTag("Scrap") && collider.gameObject.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
      {
        scrapObj = collider.gameObject;
        scrapObj.transform.SetParent(transform);
        scrapObj.transform.position = transform.position;
        ScrapModel scrapModel = scrapObj.GetComponent<ScrapModel>();
        scrapModel.ComponentStatus(false);
        scrapObj.transform.rotation = quaternion.RotateZ(0);
        break;
      }
    }
  }
}

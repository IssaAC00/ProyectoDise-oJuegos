using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
  private GameObject scrapObj;
  private ScrapModel scrapModel;
  private Camera mainCamera;
  [SerializeField] private GameObject player;
  public bool hayScrap = false;
  void Awake()
  {
    mainCamera = Camera.main;
  }

  public void OnClick(InputAction.CallbackContext context)
  {
    // Vector3 temp = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    if (!context.started) return;

    /*
    Si hay un Scrap, lo hace aparecer en la posicion del mouse con RigidBody y BoxCollider
    if (hayScrap)
    {
      scrapObj.transform.parent = null;
      Vector3 mpos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
      scrapObj.transform.position = new Vector2(mpos.x, mpos.y);
      scrapModel.ComponentStatus(true);
      hayScrap = false;
    }
    else
    {
      Se lanza un rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
    }
    */
    // Lanza rayo para detectar colision
    var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
    // Si no hay colision, se sale de la funcion
    if (!rayHit.collider) return;

    /*
    // Si hay colision y el objeto tiene tag de "Scrap", se lo da al jugador
    if (rayHit.collider.gameObject.tag.Equals("Scrap") && !hayScrap)
    {
      scrapObj = rayHit.collider.gameObject;
      scrapObj.transform.parent = player.transform;
      scrapModel = scrapObj.GetComponent<ScrapModel>();
      scrapModel.ComponentStatus(false);
      scrapObj.transform.position = player.transform.position;
      scrapObj.transform.rotation = quaternion.RotateZ(0);

      hayScrap = true;
    }
    */
    
  }
}

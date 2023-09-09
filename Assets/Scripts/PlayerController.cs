using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rb;
  private BoxCollider2D bcol;
  private float walkSpeed = 5f;
  private float jumpForce = 6f;
  private float xDirection;
  private bool canMove = false;
  private float throwSpeed = 10f;
  public Transform FirePoint;
  public GameObject Bullet;
  // private bool canJump = true;

  [SerializeField] private LayerMask jumpLayer;
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    bcol = GetComponent<BoxCollider2D>();
    canMove = true;
  }

  // Update is called once per frame
  void Update()
  {
    xDirection = Input.GetAxisRaw("Horizontal");

    if (canMove)
    {
      rb.velocity = new Vector2(xDirection * walkSpeed, rb.velocity.y);
    }

    
    // shootComponent
    if (Input.GetButtonDown("Fire1"))
    {
      for (int i = 0; i < transform.childCount; i++)
      {
        Transform child = transform.GetChild(i);
        // Debug.Log("Child name: " + child.name);
        if (child.name.Equals("Scrap"))
        {
          Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          mpos.z = 0;

          Vector3 direction = (mpos - transform.position).normalized;

          child.parent = null;
          ScrapModel smodel = child.GetComponent<ScrapModel>();
          smodel.ComponentStatus(true);
          Rigidbody2D srb = child.GetComponent<Rigidbody2D>();
          srb.velocity = direction * throwSpeed;

        }
      }
    }
    

    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
      rb.velocity = new Vector2(xDirection * walkSpeed, jumpForce);
    }
    
    if (Input.GetButtonDown("Fire1"))
    {
      Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
  }

  private bool IsGrounded()
  {
    return Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, 0.1f, jumpLayer);
  }
}

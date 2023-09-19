using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rb;
  private BoxCollider2D bcol;
  private SpriteRenderer spriteRenderer;
  private float walkSpeed = 8f;
  private float jumpForce = 13f;
  private float xDirection;
  private bool canMove = false;
  private float throwSpeed = 20f;
  private PlayerAudioManager pam;
  public Transform FirePoint;
  public GameObject Bullet;
  // private bool canJump = true;
  [SerializeField] private Animator animator;

  [SerializeField] private LayerMask jumpLayer;
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    bcol = GetComponent<BoxCollider2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    pam = FindObjectOfType<PlayerAudioManager>();
    canMove = true;
  }

  // Update is called once per frame
  void Update()
  {
    if (!canMove)
      return; // Desactiva todos los controles cuando se pasa el nivel, pausa o muere

    // Movimiento del personaje
    xDirection = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(xDirection * walkSpeed, rb.velocity.y);

    // Animaciones
    if (xDirection != 0)
      animator.SetBool("playerMove", true);
    else
      animator.SetBool("playerMove", false);

    animator.SetBool("playerJumps", !IsGrounded());
    // Voltear personaje
    if (xDirection > 0 && spriteRenderer.flipX)
    {
      spriteRenderer.flipX = false;
    }
    else if (xDirection < 0 && !spriteRenderer.flipX)
    {
      spriteRenderer.flipX = true;
    }

    // shootComponent
    if (Input.GetButtonDown("Fire2"))
    {
      // Revisa los hijos del GameObject para ver si tiene una
      // plataforma asociada.
      for (int i = 0; i < transform.childCount; i++)
      {
        Transform child = transform.GetChild(i);
        // Debug.Log("Child name: " + child.name);
        if (child.tag.Equals("Scrap"))
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
      pam.PlayJumpSound();
      rb.velocity = new Vector2(xDirection, jumpForce);
    }

    if (Input.GetButtonDown("Fire1"))
    {
      // Reproduce el sonido de disparo
      pam.PlayShootSound();
      Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
  }

  private bool IsGrounded()
  {
    return Physics2D.BoxCast(bcol.bounds.center, bcol.bounds.size, 0f, Vector2.down, 0.1f, jumpLayer);
  }

  public void SetMoveState(bool state)
  {
    canMove = state;
    if (!state)
      rb.velocity = new Vector2(0, 0);
  }

  public void ToggleMoveState()
  {
    canMove = !canMove;
  }
}

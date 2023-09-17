using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    //private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    private SpriteRenderer spriteRend;

    [Header("Game Over")]
    private UIManager uiManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        //anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void TakeDamage(float dmgAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmgAmount, 0, startingHealth);
        if (currentHealth > 0)
        {
            //Player is hurt
            //anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            //Player dies
            if (!dead) //Evita que se ejecute varias veces
            {
                //anim.SetTrigger("die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                uiManager.GameOver();
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Color colorDefault = spriteRend.color;
        spriteRend.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(iFramesDuration);
        spriteRend.color = colorDefault;
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
  private AudioSource finishSound;
  private Animator animator;
  [SerializeField] private CollectibleController collectController;
  [SerializeField] private int collectiblesRequired;
  private bool levelComplete = false;
  private GameObject bgMusic;
  private void Awake()
  {
    bgMusic = GameObject.Find("BG_Music");
    animator = GetComponent<Animator>();
    finishSound = GetComponent<AudioSource>();
  }
  
  private void Update()
  {
    if(collectController.collectibleCount == collectiblesRequired)
    {
      animator.SetBool("open", true);
    }
  }
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.name == "Player" && !levelComplete)
    {
      if(collectController.collectibleCount == collectiblesRequired) // CONDICIONAL PARA GANAR NIVEL
      {
        Destroy(bgMusic);
        finishSound.Play();
        levelComplete = true;
        PlayerController movement = collision.gameObject.GetComponent<PlayerController>();
        movement.SetMoveState(false);
        Invoke("CompleteLevel", 4f);
      }
    }
  }

  private void CompleteLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
  }
}

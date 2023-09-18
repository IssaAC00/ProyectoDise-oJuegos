using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
  private AudioSource finishSound;
  [SerializeField] private CollectibleController collectController;
  [SerializeField] private int collectiblesRequired;
  private bool levelComplete = false;
  private GameObject bgMusic;
  private void Awake()
  {
    bgMusic = GameObject.Find("BG_Music");
    finishSound = GetComponent<AudioSource>();
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

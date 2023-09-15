using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
  private AudioSource finishSound;
  [SerializeField] private bool completo = true;
  private bool levelComplete = false;
  private void Awake()
  {
    finishSound = GetComponent<AudioSource>();
  }
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.name == "Player" && !levelComplete)
    {
      if(completo) // CONDICIONAL PARA GANAR NIVEL
      {
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

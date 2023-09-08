using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCompleteScene : MonoBehaviour
{
  public void RestartGame()
  {
    SceneManager.LoadScene(0);
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}

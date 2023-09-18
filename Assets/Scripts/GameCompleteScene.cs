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
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; //Sale del modo Play en el editor de Unity
    #endif
  }
}

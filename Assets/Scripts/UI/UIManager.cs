using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private AudioSource bgmSource;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Collectibles")]
    [SerializeField] private Text collectCounter;
    [SerializeField] private CollectibleController collectController; 


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        // Enter or exit pause menu
        if (!gameOverScreen.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseScreen.activeInHierarchy)
                    PauseGame(false);
                else
                    PauseGame(true);
            }
        }
        // Update the collectible counter
        collectCounter.text = ":" + collectController.collectibleCount.ToString();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        //bgmSource.clip = gameOverSound;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        bgmSource.volume = 0.16f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
        {
            Time.timeScale = 0;
            bgmSource.volume = 0.05f;
        }
        else
        {
            Time.timeScale = 1;
            bgmSource.volume = 0.16f;
        }  
    }
}

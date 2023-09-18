using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private CollectibleController collectController;
    [SerializeField] private int collectiblesRequired;
    private bool levelComplete = false;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplete)
        {
            if (collectController.collectibleCount == collectiblesRequired) // CONDICIONAL PARA GANAR NIVEL
            {
                
              
                levelComplete = true;
                PlayerController movement = collision.gameObject.GetComponent<PlayerController>();
                movement.SetMoveState(false);
                Invoke("CompleteLevel", 4f);
            }
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

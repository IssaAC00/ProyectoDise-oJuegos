using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    
    private void Start()
    {
        //Coloca la cantidad maxima de corazones al inicio del juego
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        //Mantiene la barra de salud actualizada constantemente
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}

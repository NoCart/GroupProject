using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GameObject gameOverPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
        GameManager.onGameOver += DisplayGameOverScreen;
    }

    public void DisplayGameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

}

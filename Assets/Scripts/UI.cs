using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject endingTextObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        gameOverPanel = GameObject.Find("GameOverPanel");
        endingTextObj = GameObject.Find("GameOverText");
        gameOverPanel.SetActive(false);
        GameManager.onGameOver += DisplayGameOverScreen;
        GameManager.onGameWin += DisplayGameWinScreen;
    }

    public void DisplayGameOverScreen()
    {
        endingTextObj.GetComponent<TMP_Text>().text = "Game Over";
        gameOverPanel.SetActive(true);
    }
    public void DisplayGameWinScreen()
    {
        endingTextObj.GetComponent<TMP_Text>().text = "Success";
        gameOverPanel.SetActive(true);
    }

    public void playAgain()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
        gameOverPanel = GameObject.Find("GameOverPanel");
        endingTextObj = GameObject.Find("GameOverText");
    }

    public void OnDestroy()
    {
        GameManager.onGameOver -= DisplayGameOverScreen;
        GameManager.onGameWin -= DisplayGameWinScreen;
    }

    public void mainMenu()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }


}

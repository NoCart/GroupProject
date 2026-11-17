using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TMP_Text textMesh;
    
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        GameManager.updateScore += onScoreUpdated;
        GameManager.resetScore();
    }

    // Update is called once per frame
    void onScoreUpdated()
    {
        textMesh.text = "Score: " + (GameManager.getScore());
    }
}

using UnityEngine;
using TMPro;

public class EndGoal : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        text.text = "Wow you found me";
        GameManager.onGameWin.Invoke();
        GameManager.freezePlayer.Invoke();
        //GameManager.setSong(backgroundMusic);
    }
}

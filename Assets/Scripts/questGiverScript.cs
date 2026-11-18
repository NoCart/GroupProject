using TMPro;
using UnityEngine;

public class questGiverScript : MonoBehaviour
{
    //[SerializeField] public AudioClip regularBackgroundMusic;
    public TextMeshPro text;

    private bool hasGivenQuest = false;
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null || hasGivenQuest)
        {
            return;
        }
        hasGivenQuest = true;
        text.text = "Can you find my twin?";
        print("ENTERED");
       //GameManager.setSong(backgroundMusic);
    }
}

using TMPro;
using UnityEngine;

public class questGiverScript : MonoBehaviour
{
    [SerializeField] public AudioClip regularBackgroundMusic;
    public TextMeshPro text;

    private bool hasGivenQuest = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (regularBackgroundMusic == null)
        {
            regularBackgroundMusic = (AudioClip)Resources.Load("Assets/Music/AdventurousBGMusic.wav");
        }
    }

    // Update is called once per frame
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
        text.text = "Can you deliver my books";
        print("ENTERED");
        GameManager.setSong(regularBackgroundMusic);
    }
}

using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.updateBackgroundMusic += onBackgroundMusicChanged;
    }

    // Update is called once per frame
    void onBackgroundMusicChanged()
    {
        if (GameManager.Instance.song != null)
        {
            GetComponent<AudioSource>().generator = GameManager.Instance.song;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }
    
}

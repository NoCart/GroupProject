using UnityEngine;

public class Coin : MonoBehaviour
{
    
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }

        print("COIN PICKED UP");

        gameObject.SetActive(false);

        GameManager.IncreaseScore(100);

        Destroy(gameObject);
        
    }
}

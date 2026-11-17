using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("HIT");
        if (other != null)
        {
            other.gameObject.GetComponent<HealthComponent>().takeDamage(1);
        }
    }

}

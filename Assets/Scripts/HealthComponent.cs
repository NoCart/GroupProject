using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public UnityAction onTakeDamage;

    public int maxHealth;

    private int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();
    }

    public int getHealth()
    {
        return health;
    }

}

using UnityEngine;

public class Player : MonoBehaviour
{
    [System.NonSerialized] public Vector3 lastSafePosition = Vector3.zero;

    private HealthComponent healthComponent;
    private Rigidbody2D rb;
    private StateMachine stateMachine;

    private int health = 0;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        healthComponent = GetComponent<HealthComponent>();
        rb = GetComponent<Rigidbody2D>();
        healthComponent.onTakeDamage += onTakeDamage;
    }

    public void onTakeDamage()
    {
        health = healthComponent.getHealth();
        if (health <= 0)
        {
            stateMachine.TransitionTo(GetComponent<DeathState>());
            GameManager.onGameOver.Invoke();
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            gameObject.transform.position = lastSafePosition;
        }
    }

}

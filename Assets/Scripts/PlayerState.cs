using UnityEngine;

public class PlayerState : MonoBehaviour, IState
{
    public StateMachine stateMachine;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
    }
}

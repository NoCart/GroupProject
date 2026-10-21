using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour, IState
{
    public StateMachine stateMachine;
    public Rigidbody2D rb;

    public bool jumpPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
    }
    public void OnJump(InputValue value)
    {
        jumpPressed = Convert.ToBoolean(value.Get<float>());
    }

    public bool IsOnFloor()
    {
        
        RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), 0.5f, -Vector2.up, 0.3f, LayerMask.GetMask("Ground"));
        Debug.DrawLine(transform.position, hit.point, Color.red);
        return hit;
    }
}

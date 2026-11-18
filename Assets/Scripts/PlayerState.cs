using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour, IState
{
    [System.NonSerialized] public StateMachine stateMachine;
    [System.NonSerialized] public Rigidbody2D rb;
    [System.NonSerialized] public Animator animator;
    [System.NonSerialized] public Player player;

    [System.NonSerialized] public bool jumpPressed;
    [System.NonSerialized] public float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        player = GetComponent<Player>();
    }
    public void OnJump(InputValue value)
    {
        jumpPressed = Convert.ToBoolean(value.Get<float>());
    }

    public void OnRun(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }

    public bool IsOnFloor()
    {
        
        RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), 0.25f, -Vector2.up, 0.8f, LayerMask.GetMask("Ground"));
        Debug.DrawLine(transform.position, hit.point, Color.red);
        return hit;
    }

    public bool IsOnSafeGround()
    {

        RaycastHit2D hit1 = Physics2D.CircleCast(new Vector2(transform.position.x + 2, transform.position.y), 0.25f, -Vector2.up, 0.75f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit2 = Physics2D.CircleCast(new Vector2(transform.position.x - 2, transform.position.y), 0.25f, -Vector2.up, 0.75f, LayerMask.GetMask("Ground"));
       
        return hit1 && hit2 && IsOnFloor();
    }

    public bool IsOnWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), 0.3f, direction, 0.4f, LayerMask.GetMask("Ground"));
        Debug.DrawLine(transform.position, hit.point, Color.red);
        return hit;
    }
}

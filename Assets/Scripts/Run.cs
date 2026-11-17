using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunState : PlayerState, IState
{
    public float speed = 10.0f;
    public float groundAcceleration = 0.1f;

    private bool is_on_ground;

    private float state_switch_speed = 0.05f;

    private float state_switch_buffer = 0.0f;

    public void Enter()
    {
        animator.Play("Walk");
        state_switch_buffer = 0;
    }


    public void StateUpdate()
    {
        if (horizontalInput == 0)
        {
            stateMachine.TransitionTo(GetComponent<IdleState>());
        }
        else if (horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void StateFixedUpdate()
    {
        if (IsOnSafeGround())
        {
            player.lastSafePosition = gameObject.transform.position;
        }
        if (!IsOnFloor() || jumpPressed)
        {
            if (state_switch_buffer >= state_switch_speed || jumpPressed)
            {
                stateMachine.TransitionTo(GetComponent<AirState>());
            }
            else
            {
                state_switch_buffer += Time.deltaTime;
            }
        }
        rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, horizontalInput * speed, groundAcceleration * Time.deltaTime);
    }
}

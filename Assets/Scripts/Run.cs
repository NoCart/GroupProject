using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunState : PlayerState, IState
{
    public float speed = 10.0f;

    private bool is_on_ground;
    private float horizontalInput;
    public void OnRun(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }


    public void StateUpdate()
    {
        if (horizontalInput == 0)
        {
            stateMachine.TransitionTo(GetComponent<IdleState>());
        }
    }

    public void StateFixedUpdate()
    {
        if (!IsOnFloor() || jumpPressed)
        {
            stateMachine.TransitionTo(GetComponent<AirState>());
            return;
        }
        rb.linearVelocityX = horizontalInput * speed;
    }
}

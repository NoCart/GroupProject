using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : PlayerState, IState
{

    private float horizontalInput;
    public void Enter()
    {
        rb.linearVelocity = Vector2.zero;
    }
    public void OnRun(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }
    public void StateUpdate()
    {
        if (horizontalInput != 0)
        {
            stateMachine.TransitionTo(GetComponent<RunState>());
        }
        if (!IsOnFloor() || jumpPressed)
        {
            stateMachine.TransitionTo(GetComponent<AirState>());
            return;
        }
    }
}

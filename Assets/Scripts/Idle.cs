using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class IdleState : PlayerState, IState
{
    public void Enter()
    {
        if (IsOnSafeGround())
        {
            player.lastSafePosition = gameObject.transform.position;
        }
        animator.Play("Idle");
        rb.linearVelocity = Vector2.zero;
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

using UnityEngine;

public class Idle : PlayerState, IState
{

    void Enter()
    {
        rb.linearVelocity = Vector2.zero;
    }

    private void StateUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //stateMachine.TransitionTo(run)
        }
    }
}

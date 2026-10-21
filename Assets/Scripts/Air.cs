using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirState : PlayerState, IState
{
    public float jumpForce = 12.0f;
    public float UpGravity = 20.0f;
    public float DownGravity = 20.0f;
    public float defaultHoldTime = 0.1f;
    public float airSpeed = 10.0f;


    private float holdTime = 0.0f;
  

    public void Enter()
    {
        if (jumpPressed)
        {
            rb.linearVelocityY = jumpForce;
            holdTime = defaultHoldTime;
        }
    }

    private float horizontalInput;
    public void OnRun(InputValue value)
    {
        horizontalInput = value.Get<float>();
    }
    public void StateFixedUpdate()
    {
        if (IsOnFloor() && jumpPressed)
        {
            rb.linearVelocityY = jumpForce;
            holdTime = defaultHoldTime;
        }
        else if (IsOnFloor() && Math.Abs(rb.linearVelocityY) < 0.1)
        {
            stateMachine.TransitionTo(GetComponent<RunState>());
        }
        rb.linearVelocityX = horizontalInput * airSpeed;

        if (rb.linearVelocityY - UpGravity * Time.deltaTime < 0 && holdTime > 0)
        {
            holdTime -= Time.deltaTime;
        }
        else if (rb.linearVelocityY > 0)
        {
            rb.linearVelocityY -= UpGravity * Time.deltaTime;
        }
        else if (rb.linearVelocityY <= 0)
        {
            rb.linearVelocityY -= DownGravity * Time.deltaTime;
        }
    }

}

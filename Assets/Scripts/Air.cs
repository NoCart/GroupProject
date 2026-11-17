using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirState : PlayerState, IState
{
    public float jumpForce = 12.0f;
    public float UpGravity = 20.0f;
    public float DownGravity = 20.0f;
    public float defaultHoldTime = 0.1f;
    public float airSpeed = 10.0f;
    public float airAcceleration = 0.5f;


    private float holdTime = 0.0f;
    private bool playedFallAnimation = false;
    private bool floating = false;
    private bool startedFloating = false;
    private double floatTime = 0.0f;
  

    public void Enter()
    {
        if (jumpPressed)
        {
            rb.linearVelocityY = jumpForce;
            holdTime = defaultHoldTime;
            animator.Play("Jump");
            playedFallAnimation = false;
        }
        else
        {
            animator.Play("Fall");
            playedFallAnimation = true;
        }
    }
    public void StateFixedUpdate()
    {
        // Hitting floor
        if (IsOnFloor() && jumpPressed)
        {
            startedFloating = false;
            rb.linearVelocityY = jumpForce;
            holdTime = defaultHoldTime;
            animator.Play("Jump");
        }
        else if (IsOnFloor() && Math.Abs(rb.linearVelocityY) < 0.1)
        {
            startedFloating = false;
            if (horizontalInput == 0)
            {
                stateMachine.TransitionTo(GetComponent<IdleState>());
            }
            else
            {
                stateMachine.TransitionTo(GetComponent<RunState>());
            }
        }
        int dir = 0;
        if (GetComponent<SpriteRenderer>().flipX == true)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        if (IsOnWall(new Vector2(dir, 0.0f)))
        {
            stateMachine.TransitionTo(GetComponent<WallSlide>());
        }

        // Moving horizontally in air
       
        rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, horizontalInput * airSpeed, airAcceleration * Time.deltaTime);


        // If the player velocity y goes from up to down trigger floating
        if (rb.linearVelocityY - UpGravity * Time.deltaTime < 0 && startedFloating == false)
        {
            startedFloating = true;
            floating = true;
            floatTime = Time.time;
            rb.linearVelocityY = 0;

        }
        // floating
        
        if (floating == true)
        {
            if (Time.time - floatTime > holdTime) { floating = false; }
        }
        // Falling and rising
        else if (rb.linearVelocityY > 0)
        {
            rb.linearVelocityY -= UpGravity * Time.deltaTime;
        }
        else if (rb.linearVelocityY <= 0)
        {
            if (playedFallAnimation == false)
            {
                animator.Play("Fall");
            }
            rb.linearVelocityY -= DownGravity * Time.deltaTime;
        }

        // Flipping sprite directionally
        if (horizontalInput > 0) GetComponent<SpriteRenderer>().flipX = false; if (horizontalInput < 0) GetComponent<SpriteRenderer>().flipX = true;
    }

}

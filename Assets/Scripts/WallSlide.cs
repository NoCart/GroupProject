using Unity.Mathematics;
using UnityEngine;

public class WallSlide : PlayerState, IState
{
    public float UpSlide = 9.81f;
    public float DownSlide = 9.81f;
    public float wallSlideMaxSpeed = 0.0f;
    public float wallJumpHorizontalSpeed = 10.0f;

    private float state_switch_speed = 0.1f;

    private float state_switch_buffer = 0.0f;

    Vector2 initialDirection;
    public void Enter()
    {
        int dir = 0;
        if (GetComponent<SpriteRenderer>().flipX == true)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        initialDirection = new Vector2(dir, 0);
        state_switch_buffer = 0;
    }
    public void StateFixedUpdate()
    {
        // Exiting State
        if (horizontalInput == -initialDirection.x)
        {
            if (state_switch_buffer >= state_switch_speed)
            {
                stateMachine.TransitionTo(GetComponent<AirState>());
            }
            else
            {
                state_switch_buffer += Time.deltaTime;
            }
        }
        else if (!IsOnWall(initialDirection))
        {
            if (state_switch_buffer >= state_switch_speed)
            {
                stateMachine.TransitionTo(GetComponent<AirState>());
            }
            else
            {
                state_switch_buffer += Time.deltaTime;
            }
        }
        else
        {
            state_switch_buffer = 0.0f;
        }
        if (IsOnFloor())
        {
            stateMachine.TransitionTo(GetComponent<IdleState>());
        }
        if (jumpPressed)
        {
            rb.linearVelocityY = GetComponent<AirState>().jumpForce;
            rb.linearVelocityX = wallJumpHorizontalSpeed * -initialDirection.x;
            stateMachine.TransitionTo(GetComponent<AirState>());
        }


        // Sliding
        if (rb.linearVelocityY > 0)
        {
            rb.linearVelocityY -= UpSlide * Time.deltaTime;
        }
        else if (rb.linearVelocityY <= 0)
        {
            rb.linearVelocityY -= DownSlide * Time.deltaTime;
        }

        if (Mathf.Abs(rb.linearVelocityY) > wallSlideMaxSpeed)
        {
            rb.linearVelocityY = (rb.linearVelocityY / Mathf.Abs(rb.linearVelocityY)) * wallSlideMaxSpeed;
        }
    }

}

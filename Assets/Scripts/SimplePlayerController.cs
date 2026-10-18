using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SimplePlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput input;

    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float UpGravity = 9.81f;
    public float DownGravity = 9.81f;
    public float defaultHoldTime = 0.1f;


    private float holdTime = 0.0f;

    public Transform feetPosition;

    private float horizontalInput = 0.0f;
    private bool jumpPressed = false;
    private bool is_on_ground = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    public void onHorizontalInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        jumpPressed = context.performed;
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = horizontalInput * speed;
        
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

            RaycastHit2D hit = Physics2D.CircleCast(feetPosition.position, 0.5f, -Vector2.up, 0.01f, LayerMask.GetMask("Ground"));
        is_on_ground = hit;

        if (is_on_ground && jumpPressed)
        {
            rb.linearVelocityY = jumpForce;
            holdTime = defaultHoldTime;
        }
    }
}

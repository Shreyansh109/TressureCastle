using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Vector2 movementInput;
    //Vector2 playerMovement;

    bool isGrounded = false;
    bool isJump;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Fall();
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        //character flip according to movement direction
        if(movementInput.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if(movementInput.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void OnJump(InputValue value)
    {
        if (isGrounded && value.isPressed)
        {
            rb.linearVelocityY = 7f;
            isJump = true;
        }
        if(value.isPressed == false)
        {
            isJump = false;
        }
    }

    void Run()
    {
        //playerMovement = new Vector2(movementInput.x, 0f);
        rb.linearVelocityX = movementInput.x * 3f;
        // rb.linearVelocityY = 2f;
    }

    void Fall()
    {
        //character fall down when not grounded, by increasing the downward velocity
        if (!isGrounded && !isJump)
        {
            rb.linearVelocityY = -5f;
        }else if(isGrounded && !isJump)
        {
            rb.linearVelocityY = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}

using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    Vector2 playerMovement;

    bool isGrounded = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Fall();
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        if(movementInput.x > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        else if(movementInput.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
    }

    void Run()
    {
        //playerMovement = new Vector2(movementInput.x, 0f);
        rb.linearVelocityX = movementInput.x * 3f;
        // rb.linearVelocityY = 2f;
    }

    void Fall()
    {
        if (!isGrounded)
        {
            rb.linearVelocityY = -5f;
        }else
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

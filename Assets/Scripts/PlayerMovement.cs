using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Vector2 movementInput;
    //Vector2 playerMovement;

    bool isGrounded = false;
    bool isJump;
    bool isLadder = false;
    bool isAlive = true;

    Rigidbody2D rb;
    Light2D light;

    [SerializeField] GameObject canvasPressClimb;
    [SerializeField] GameObject globalLight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        light = globalLight.GetComponent<Light2D>();
    }

    void Update()
    {
        Run();
        Fall();
        Climb();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) return;
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
        if (!isAlive) return;
        if (isGrounded && value.isPressed)
        {
            rb.linearVelocityY = 7f;
            isJump = true;
        }

        if (!value.isPressed)
        {
            isJump = false;
            print("isJump: " + isJump);
        }
    }

    void Run()
    {
        if (!isAlive) return;
        //playerMovement = new Vector2(movementInput.x, 0f);
        rb.linearVelocityX = movementInput.x * 3f;
        // rb.linearVelocityY = 2f;
    }

    void Fall()
    {
        //character fall down when not grounded, by increasing the downward velocity
        if (!isGrounded && !isJump && !isLadder)
        {
            rb.linearVelocityY = -5f;
        }else if(isGrounded && !isJump && !isLadder)
        {
            rb.linearVelocityY = 0f;
        }
    }

    void Climb()
    {
        //print("isLadder: " + isLadder + " movementInput.y: " + movementInput.y + " isJump: " + isJump);
        if (isLadder && movementInput.y > 0f)
        {
            rb.linearVelocityY = 3f;
            animator.SetBool("isClimbing", true);
            //rb.gravityScale = 0f;
        }else if (isLadder && movementInput.y < 0f)
        {
            rb.linearVelocityY = -3f;
            animator.SetBool("isClimbing", true);
            //rb.gravityScale = 0f;
        }
        else if (isLadder && movementInput.y == 0f)
        {
            //rb.linearVelocityY = 0f;
            animator.SetBool("isClimbing", false);
            //rb.gravityScale = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Platform" || LayerMask.LayerToName(collision.gameObject.layer) == "Bounce")
            isGrounded = true;
        //isJump = false;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Platform" || LayerMask.LayerToName(collision.gameObject.layer) == "Bounce")
            isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Climb")
        {
            isLadder = true;
            canvasPressClimb.SetActive(true);
        }
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Water")
        {
            isAlive = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Climb")
        {
            isLadder = true;
            canvasPressClimb.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Climb")
        {
            isLadder = false;
            rb.linearVelocityY = 0f;
            animator.SetBool("isClimbing", false);
            canvasPressClimb.SetActive(false);
        }
    }

    void Die()
    {
        if (!isAlive){
            animator.SetTrigger("isDie");
            if(light.intensity > 0f)
            {
                light.intensity -= Time.deltaTime * 0.5f;
            }
        }
    }
}

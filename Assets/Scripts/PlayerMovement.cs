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


    [SerializeField] GameObject canvasPressClimb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Fall();
        Climb();
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
            print(isGrounded);
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
            rb.linearVelocityY = -7f;
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

    public bool getAlive()
    {
        return isAlive;
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }

    public void setGrounded(bool grounded)
    {
        isGrounded = grounded;

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
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            Destroy(collision.gameObject, 0.1f);
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
}

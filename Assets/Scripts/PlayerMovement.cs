using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    Vector2 playerMovement;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void Run()
    {
        playerMovement = new Vector2(movementInput.x, 0f);
        rb.linearVelocity = playerMovement * 2.5f;
    }
}

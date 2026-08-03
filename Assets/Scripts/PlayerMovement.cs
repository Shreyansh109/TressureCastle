using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        print(movementInput);
    }
}

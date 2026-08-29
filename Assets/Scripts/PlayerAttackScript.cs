using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    BoxCollider2D attackCollider;
    PlayerMovement playerMovement;

    void Start()
    {
        attackCollider = GetComponent<BoxCollider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Platform" ||
            LayerMask.LayerToName(collision.gameObject.layer) == "Bounce")
        {
            playerMovement.setGrounded(true);
        }
        else if(attackCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(collision.gameObject, 0.1f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Platform" ||
            LayerMask.LayerToName(collision.gameObject.layer) == "Bounce")
        {
            playerMovement.setGrounded(false);
        }
    }
}

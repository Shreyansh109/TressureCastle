using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem enemyDiePS;
    BoxCollider2D feetCollider;
    PlayerMovement playerMovement;

    void Start()
    {
        feetCollider = GetComponent<BoxCollider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) ||
            feetCollider.IsTouchingLayers(LayerMask.GetMask("Bounce")))
        {
            playerMovement.setGrounded(true);
        }
        else if(feetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            if (enemyDiePS != null)
            {
                print("Particle Play!!");
                enemyDiePS.Play();
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) ||
            !feetCollider.IsTouchingLayers(LayerMask.GetMask("Bounce")))
        {
            playerMovement.setGrounded(false);
        }
    }
}

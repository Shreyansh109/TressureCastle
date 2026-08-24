using UnityEngine;

public class Health : MonoBehaviour
{
    private short currentHealth = 3;
    [SerializeField] private GameObject[] healthIcons;
    
    void hitHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            healthIcons[currentHealth].SetActive(false);
        }
    }

    void Die(){}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy" ||
            LayerMask.LayerToName(collision.gameObject.layer) == "Hazards")
        {
            hitHealth();
        }
        else
        {
            Die();
        }
    }
}

using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    private short currentHealth = 3;
    Light2D light;
    BoxCollider2D playerCollider;

    [SerializeField] private GameObject[] healthIcons;
    [SerializeField] GameObject globalLight;
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] ParticleSystem particleSystem;

    void Start()
    {
        light = globalLight.GetComponent<Light2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Die();
    }
    
    void hitHealth()
    {
        if (currentHealth > 0 && !playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            currentHealth--;
            healthIcons[currentHealth].SetActive(false);
            particleSystem.Play();
        }
    }

    void Die()
    {
        if (!playerMovement.getAlive() || currentHealth <= 0){
            animator.SetTrigger("isDie");
            for (int i =  healthIcons.Length-1; i >= 0; i--)
            {
                healthIcons[i].SetActive(false);
            }
            if(light.intensity > 0f)
            {
                light.intensity -= Time.deltaTime * 0.5f;
            }
        }else return;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Hazards") 
        {
            hitHealth();
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy" && !playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            print("Player hit by enemy");
            playerMovement.setAlive(false);
            currentHealth = 0;
            Die();
        }
    }
}

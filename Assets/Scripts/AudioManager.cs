using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource LoseMusic;

    [Header("Component References")]
    [SerializeField] PlayerMovement playerMovement;

    [Header("Environment Sound")]
    [SerializeField] AudioSource DeathAudioSource;

    [Header("Player Sound")]
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip runSound;
    [SerializeField] AudioClip hazardsSound;


    bool DieSFXplayed = false;
    Vector2 movementInput;

    void Update()
    {
        DieSFX();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Water")
        {
            BGM.Pause();
            LoseMusic.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Hazards")
        {
            playerAudioSource.PlayOneShot(hazardsSound);
        }
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        if(playerMovement.getAlive() && movementInput.x != 0)
        {
            playerAudioSource.clip = runSound;
            if(!playerAudioSource.isPlaying)
            {
                playerAudioSource.Play();
            }
        }else if(movementInput.x == 0)
        {
            playerAudioSource.Pause();
        }
    }

    void OnJump(InputValue value)
    {
        if(playerMovement.getAlive() && playerMovement.getJump())
        {
            playerAudioSource.PlayOneShot(jumpSound);
        }
    }

    void DieSFX()
    {
        if(!playerMovement.getAlive() && !DieSFXplayed)
        {
            DeathAudioSource.Play();
            DieSFXplayed = true;
        }else return;
    }

}

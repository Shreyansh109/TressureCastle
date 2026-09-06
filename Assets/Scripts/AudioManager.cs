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

    bool DieSFXplayed = false;

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

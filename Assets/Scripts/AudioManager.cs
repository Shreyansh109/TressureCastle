using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource LoseMusic;

    [Header("Component References")]
    [SerializeField] PlayerMovement playerMovement;

    [Header("Player Sound")]
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioClip jumpSound;

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

}

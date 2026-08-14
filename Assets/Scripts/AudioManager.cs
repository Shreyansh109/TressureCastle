using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Water")
        {
            BGM.Pause();
        }
    }
}

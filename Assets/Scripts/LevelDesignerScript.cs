using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesignerScript : MonoBehaviour
{
    [SerializeField] private GameObject coinCanvas;
    void Start()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            coinCanvas.gameObject.SetActive(false);
        }
    }
}

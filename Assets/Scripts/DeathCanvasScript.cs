using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvasScript : MonoBehaviour
{
    [SerializeField] private CoinHandler coinHandler;
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        coinHandler.CoinCount = 0;
    }
}

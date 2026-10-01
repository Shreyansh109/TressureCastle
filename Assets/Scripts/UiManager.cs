using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Death Canvas")]
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject ControlCanvas;
    [SerializeField] GameObject HealthCanvas;
    [SerializeField] GameObject CoinCanvas;
    [SerializeField] GameObject PauseMenuPanel;


    public void DeathGame()
    {
        PauseCanvas.SetActive(false);
        ControlCanvas.SetActive(false);
        HealthCanvas.SetActive(false);
        CoinCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseCanvas.SetActive(true);
        ControlCanvas.SetActive(true);
        HealthCanvas.SetActive(true);
        CoinCanvas.SetActive(true);
        Time.timeScale = 1f;
        PauseMenuPanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

}

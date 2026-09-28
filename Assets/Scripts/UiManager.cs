using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Death Canvas")]
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject ControlCanvas;
    [SerializeField] GameObject HealthCanvas;
    [SerializeField] GameObject CoinCanvas;

    public void DeathGame()
    {
        PauseCanvas.SetActive(false);
        ControlCanvas.SetActive(false);
        HealthCanvas.SetActive(false);
        CoinCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

}

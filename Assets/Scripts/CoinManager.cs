using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private CoinHandler coinHandler;
    //private int coinCount;

    void Start()
    {
        UpdateCoinText(coinHandler.CoinCount);
    }

    void UpdateCoinText(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }

    void AddCoin(int amount)
    {
        coinHandler.CoinCount += amount;   
        UpdateCoinText(coinHandler.CoinCount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Coin")
        {
            AddCoin(1);
            if(!coinSound.isPlaying) coinSound.Play();
            Destroy(other.gameObject);
        }
    }
    
}

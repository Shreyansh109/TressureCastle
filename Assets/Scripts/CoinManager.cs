using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private AudioSource coinSound;
    private int coinCount = 0;

    void Start()
    {
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = coinCount.ToString();
    }

    void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(LayerMask.LayerToName(other.gameObject.layer) == "Coin")
        {
            AddCoin(1);
            coinSound.Play();
            Destroy(other.gameObject);
        }
    }
    
}

using UnityEngine;

[CreateAssetMenu(fileName = "CoinHandler", menuName = "Scriptable Objects/CoinHandler")]
public class CoinHandler : ScriptableObject
{
    [SerializeField] private int _coinCount = 0;

    public int CoinCount
    {
        get { return _coinCount; }
        set { _coinCount = value; }
    }
}

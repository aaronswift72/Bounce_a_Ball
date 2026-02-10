using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int totalCoins { get; private set; } = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        totalCoins++;
        Debug.Log("Coins: " + totalCoins);
        
        // TODO: Update UI here later
    }

    public bool SpendCoins(int amount)
    {
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            Debug.Log("Spent " + amount + " coins. Remaining: " + totalCoins);
            return true;
        }
        return false;
    }
}
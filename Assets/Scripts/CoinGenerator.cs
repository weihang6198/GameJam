using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;
    public int coinCount = 4;
    public float coinSpacing = 1.0f;

    public Transform[] spawnPoints;

    void Awake()
    {
        MakeLinedCoin();
    }

    void MakeLinedCoin()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 basePosition = spawnPoints[spawnIndex].position;

        float coinWidth = coin.GetComponent<SpriteRenderer>().bounds.size.x;

        for (int coinIndex = 0; coinIndex < coinCount; coinIndex++)
        {
            Vector3 position = basePosition + new Vector3(coinIndex * (coinWidth + coinSpacing), 0, 0);
            GameObject CoinIns = Instantiate(coin, position, transform.rotation);
            CoinIns.GetComponent<CoinScript>().coinGenerator = this;

            CoinScript coinScript = CoinIns.GetComponent<CoinScript>();
            coinScript.coinGenerator = this;

            if (coinIndex == coinCount - 1)   
            {
                coinScript.isLeader = true;
            }
        }
    }

    public void NextSpawnLinedCoin()
    {
        float randomWait = Random.Range(2.0f, 4.0f);
        Invoke("MakeLinedCoin", randomWait);
    }
}

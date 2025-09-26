using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;
    public int coinCount = 4;
    public float coinSpacing = 1.0f;
    public float currentSpeed = 2.0f;

    public Transform[] spawnPoints;

    void Awake()
    {
        NextSpawnLinedCoin();
    }

    public void NextSpawnLinedCoin()
    {
        float randomWait = Random.Range(2.0f, 4.0f);
        Invoke(nameof(MakeLinedCoin), randomWait);
    }

    void MakeLinedCoin()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 basePosition = spawnPoints[spawnIndex].position;

        for (int coinIndex = 0; coinIndex < coinCount; coinIndex++)
        {
            Vector3 position = basePosition + new Vector3(coinIndex * coinSpacing, 0, 0);
            GameObject coinIns = Instantiate(coin, position, Quaternion.identity);

            CoinScript coinScript = coinIns.GetComponent<CoinScript>();
           // coinScript.coinGenerator = this;

            //oinScript.isLeader = (coinIndex == 0);
        }
    }
}

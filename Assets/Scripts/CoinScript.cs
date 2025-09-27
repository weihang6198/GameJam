using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinGenerator coinGenerator;
    public float currentSpeed = 4.0f;
    public bool isLeader = false;

    void Update()
    {
        if (coinGenerator != null)
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLeader && collision.gameObject.CompareTag("NextLine"))
        {
            coinGenerator.NextSpawnLinedCoin();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}

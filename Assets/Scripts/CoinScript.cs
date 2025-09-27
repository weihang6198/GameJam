using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinGenerator coinGenerator;
    public float currentSpeed = 4.0f;
    public bool isLeader = false;

    public AudioClip coinSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            if (audioSource != null && coinSound != null)
                audioSource.PlayOneShot(coinSound);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, coinSound.length);
        }
    }
}

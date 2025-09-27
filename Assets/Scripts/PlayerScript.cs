using UnityEngine;
using UnityEngine.UI;
using TMPro; // You must include this namespace
using FirstGearGames.SmoothCameraShaker;
public class PlayerScript : MonoBehaviour
{

    public ParticleSystem jetpackParticles; // assign in Inspector
    public ParticleSystem FireParticles; // assign in Inspector
    public ShakeData explosionShakeData;
    float Score;
    public int Health;
    public int MaxHealth;

    //動き
    public float jetpackSpeed = 5f;
    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    Rigidbody2D RB;

    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI HealthTxt;

    //初期setting
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Score = 0;
        Health = MaxHealth;
    }

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            // CameraShake();
            if (!jetpackParticles.isPlaying)
                jetpackParticles.Play();
            RB.linearVelocity = new Vector2(RB.linearVelocity.x, jetpackSpeed);
        }
        else
        {
            if (jetpackParticles.isPlaying)
                jetpackParticles.Stop();
        }
        //スコアの表示
        if (isAlive)
        {

            ShowHealth();
            ShowScore();
        }
    }

    //床にいるの確認
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            //isAlive = false;
            //Time.timeScale = 0;
            ReduceHealth(1);
        }
    }

    private void ShowHealth()
    {

        HealthTxt.text = "HEALTH:" + Health.ToString("F");

    }

    private void ShowScore()
    {
        Score += Time.deltaTime * 4;
        ScoreTxt.text = "SCORE:" + Score.ToString("F");
    }

    public void ReduceHealth(int amount)
    {
        Debug.Log("reduce health");
        if (Health > 0)
        {
            Health -= amount;
        }
    }

    public void CameraShake()
    {
        Debug.Log("camera shake ");
        if (explosionShakeData != null)
        {
            CameraShakerHandler.Shake(explosionShakeData);
        }
        else
        {
            Debug.Log("camera shake empty");
        }

    }

    public void ExplosionParticle()
    {
        FireParticles.Play();
    }
}
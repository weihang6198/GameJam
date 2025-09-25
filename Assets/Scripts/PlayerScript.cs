
using UnityEngine;
using UnityEngine.UI;
using TMPro; // You must include this namespace
public class PlayerScript : MonoBehaviour
{

    public float JumpForce;
    float Score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    Rigidbody2D RB;

   public TextMeshProUGUI ScoreTxt;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if (isGrounded)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            Score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE:" + Score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
    
    
}

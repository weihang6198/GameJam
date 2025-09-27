using System.Collections.Generic;
using UnityEngine;

public class ColorWallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //square 1-4 �܂ł�o�^���܂��B
    public List<SpriteRenderer> mySpriteRenderer = new List<SpriteRenderer>();
    public List<Sprite> sprites = new List<Sprite>();
    public InputRecorder input;

    public List<int> colorWallRandomIndices = new List<int>();

    public float speed;
    // A public reference to the Sprite Renderer component

     public SpikeGenerator spikeGenerator;
    void Start()
    {
        
         GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            input = player.GetComponent<InputRecorder>();
            Debug.Log("player input reocrder is found");
        }
       
        RandomColor();
        
        speed = 4f;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        CheckPlayerInput();
        
    }

    void RandomColor()
    {

        for (int i = 0; i < mySpriteRenderer.Count; i++)
        {
            int randomIndex = Random.Range(0, sprites.Count);
            Debug.Log("Random int is:" + randomIndex);
            mySpriteRenderer[i].sprite = sprites[randomIndex];
            colorWallRandomIndices.Add(randomIndex); // store actual random index
        }
          Debug.Log("colorWallRandomIndices: " + string.Join(", ", colorWallRandomIndices));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //spawn new color wall
        if (collision.gameObject.CompareTag("NextLine"))
        {

            // spikeGenerator.GenerateColorWallWithGap();

        }
        //destroy color wall
        if (collision.gameObject.CompareTag("Finish"))

        {

            Destroy(this.gameObject);

        }

        //destroy self and damage player 
        if (collision.gameObject.CompareTag("Player"))

        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();

            if (player != null)

            {

                player.ReduceHealth(1); // Reduce health by 1
                player.CameraShake();
                player.ExplosionParticle();
            }
            Destroy(this.gameObject);
        }
    }

    public void CheckPlayerInput()
    {

        if (input.playerKeyInput.Count == 4)
        {
            Debug.Log("checking player input");
            
            //check if the keyinput is correct
            if (input.CompareInput(colorWallRandomIndices))
            {
                Debug.Log("correct answer , now des");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("incorrect answer ");
            }
        }
    }

}

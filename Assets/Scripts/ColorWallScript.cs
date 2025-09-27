using System.Collections.Generic;
using UnityEngine;

public class ColorWallParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //square 1-4 �܂ł�o�^���܂��B
    public List<GameObject> Wall = new List<GameObject>();
    public List<SpriteRenderer> mySpriteRenderer = new List<SpriteRenderer>();
    public List<Sprite> sprites = new List<Sprite>();

    public float speed;
    // A public reference to the Sprite Renderer component

    public SpikeGenerator spikeGenerator;
    void Start()
    {
        //Debug.Log("color wall parent");
        //mySpriteRenderer.sprite = sprites;

        for (int i = 0; i < mySpriteRenderer.Count; i++)
        {
            int randomIndex = Random.Range(0, mySpriteRenderer.Count);

            mySpriteRenderer[randomIndex].sprite = sprites[randomIndex];
        }
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void RandomColor()
    {
        for (int i = 0; i < mySpriteRenderer.Count; i++)
        {
            int randomIndex = Random.Range(0, sprites.Count);
            mySpriteRenderer[i].sprite = sprites[randomIndex];
        }
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

}

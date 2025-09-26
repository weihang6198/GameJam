using System.Collections.Generic;
using UnityEngine;

public class ColorWallParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //square 1-4 Ç‹Ç≈Çìoò^ÇµÇ‹Ç∑ÅB
    public List<GameObject> Wall = new List<GameObject>();
    public List<SpriteRenderer> mySpriteRenderer = new List<SpriteRenderer>();
    public List<Sprite> sprites = new List<Sprite>();

    // A public reference to the Sprite Renderer component

    void Start()
    {
        //Debug.Log("color wall parent");
        //mySpriteRenderer.sprite = sprites;

        for(int i = 0; i < mySpriteRenderer.Count; i++)
        {
            int randomIndex = Random.Range(0, mySpriteRenderer.Count);

            mySpriteRenderer[randomIndex].sprite = sprites[randomIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomColor()
    {
        for(int i = 0; i < mySpriteRenderer.Count; i++)
        {
            int randomIndex = Random.Range(0, sprites.Count);
            mySpriteRenderer[i].sprite = sprites[randomIndex];
        }
    }
}

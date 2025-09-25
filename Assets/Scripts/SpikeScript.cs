using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spikeGenerator.CurrentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLine"))
        {
            spikeGenerator.GenerateNextSpikeWithGap();
        }

         if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}

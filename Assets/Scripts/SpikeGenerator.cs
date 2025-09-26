using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float SpeedMultiplier;

    public Transform[] spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CurrentSpeed = MinSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
        
    }
    public void generateSpike()
    {


        int spawnIndex = Random.Range(0, spawnPoint.Length);
        Vector3 basePosition = spawnPoint[spawnIndex].position;
        Debug.Log("basePosition is:"+basePosition);
        GameObject SpikeIns = Instantiate(spike, basePosition, transform.rotation);
        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;

        float randomHeight = Random.Range(1.0f, 3.0f);
        Vector3 newScale = SpikeIns.transform.localScale;
        newScale.y = randomHeight;

        if (spawnIndex == 1)
        {
            newScale.y *= -1;
        }

        SpikeIns.transform.localScale = newScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += SpeedMultiplier;
        }
    }
}

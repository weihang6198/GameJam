using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour

{
    public GameObject spike;
    public GameObject colorWall;
    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float SpeedMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] SpawnPosition;
    int colorWallIndex = 2;
    [SerializeField] Vector2 spawnSpikeInterval;
     [SerializeField] Vector2 spawnColorWallInterval;
    [SerializeField] Vector2 spikeRandomScale;
    void Awake()
    {
        CurrentSpeed = MinSpeed;
        //GenerateSpike();
        GenerateColorWall();
    }



    public void GenerateNextSpikeWithGap()

    {
        float randomWait = Random.Range(spawnSpikeInterval.x, spawnSpikeInterval.y);
        Invoke("GenerateSpike", randomWait);
    }

    public void GenerateSpike()

    {
        int randomValue = Random.Range(0, 2); // 0 or 1

        GameObject SpikeIns = Instantiate(spike, SpawnPosition[randomValue].transform.position, SpawnPosition[randomValue].transform.rotation);
        Vector3 currentScale = SpikeIns.transform.localScale;

        int randomScale = Random.Range((int)spikeRandomScale.x, (int)spikeRandomScale.y); // 0 or 1
        SpikeIns.transform.localScale = new Vector3(
        currentScale.x,
        currentScale.y * randomScale,
        currentScale.z
    );

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
        //SpikeIns.GetComponent<SpikeScript>().Speed = MaxSpeed;
    }

    public void GenerateColorWall()
    {
        GameObject colorWallIns = Instantiate(colorWall, SpawnPosition[colorWallIndex].transform.position, SpawnPosition[colorWallIndex].transform.rotation);
        Vector3 currentScale = colorWallIns.transform.localScale;
          colorWallIns.GetComponent<ColorWallParent>().spikeGenerator = this;
    }

    public void GenerateColorWallWithGap()
    {
        float randomWait = Random.Range(spawnColorWallInterval.x, spawnColorWallInterval.y);
        
         Invoke("GenerateColorWall", randomWait);
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
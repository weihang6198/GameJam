using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // You must include this namespace
public class SpikeGenerator : MonoBehaviour

{
    public TextMeshProUGUI DistanceTxt;
    public GameObject spike;
    public GameObject colorWall;
    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float SpeedMultiplier;
    float Distance = 0f;
    int lastTriggeredDistance = 0;
    public int ColorWallSpawnDistance = 1000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] SpawnPosition;
    int colorWallIndex = 2;
    [SerializeField] Vector2 spawnSpikeInterval;
    [SerializeField] Vector2 spawnColorWallInterval;
    [SerializeField] Vector2 spikeRandomScale;
    void Awake()
    {
        CurrentSpeed = MinSpeed;
        GenerateSpike();


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
        colorWallIns.GetComponent<ColorWallScript>().spikeGenerator = this;
    }

    public void GenerateColorWallWithGap()
    {
        float randomWait = Random.Range(spawnColorWallInterval.x, spawnColorWallInterval.y);

        Invoke("GenerateColorWall", randomWait);
    }
    // Update is called once per frame
    void Update()
    {
        Distance += Time.deltaTime*5;// if distance depends on speed

        int currentDistance = (int)Distance;

        // Trigger once per interval
        if (currentDistance / ColorWallSpawnDistance > lastTriggeredDistance / ColorWallSpawnDistance)
        {
            GenerateColorWall();
            lastTriggeredDistance = currentDistance;
        }
        if (CurrentSpeed < MaxSpeed)
        {

            CurrentSpeed += SpeedMultiplier;

        }

        ShowDistance();
    }
    
     private void ShowDistance()
    {
        
        DistanceTxt.text = "Distance:" + Distance.ToString("F");
    }
}
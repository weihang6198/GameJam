using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour

{
    public GameObject spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float SpeedMultiplier;

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
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
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
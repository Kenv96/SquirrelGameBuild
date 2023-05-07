using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    private Vector3 carSpawn;
    private Quaternion carRot;
    public GameObject[] cars;
    public CarSpawnPoint[] spawnpoints;
    public float spawnrate;
    private int chosenCar;
    private int chosenSpawn;
    private int lastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CarSpawner", 2.0f, spawnrate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CarSpawner()
    {
        chosenCar = Random.Range(0, cars.Length);
        chosenSpawn = Random.Range(0, spawnpoints.Length);
        while(chosenSpawn == lastSpawn)
        {
            chosenSpawn = Random.Range(0, spawnpoints.Length);
        }
        carSpawn.x = spawnpoints[chosenSpawn].spawnx;
        carSpawn.y = spawnpoints[chosenSpawn].spawny;
        carSpawn.z = spawnpoints[chosenSpawn].spawnz;
        carRot = spawnpoints[chosenSpawn].spawnrot;
        Instantiate(cars[chosenCar], carSpawn, carRot);
        lastSpawn = chosenSpawn;
    }
}

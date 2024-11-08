using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] BatSpawners;
    public Vector2 spawnDelayRange;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(spawnTimer <= 0f)
        {
            GameObject pickedSpawner = BatSpawners[Random.Range(0, BatSpawners.Length)];
            pickedSpawner.GetComponent<BatSpawnerScript>().SpawnBat();

            ResetSpawnTime();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void ResetSpawnTime()
    {
        spawnDelay = Random.Range(spawnDelayRange.x, spawnDelayRange.y);

        spawnTimer = spawnDelay;
    }
}

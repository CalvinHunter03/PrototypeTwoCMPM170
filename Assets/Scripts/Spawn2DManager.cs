using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2DManager : MonoBehaviour
{
    public Transform[] Walls;
    public List<GameObject> BatSpawners = new List<GameObject>();
    public Vector2 spawnDelayRange;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform wall in Walls)
        {
            Debug.Log(wall);
            for(int i = 0; i < wall.childCount; i++)
            {
                Debug.Log(wall.GetChild(i).gameObject);
                BatSpawners.Add(wall.GetChild(i).gameObject);
            }
        }
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
            GameObject pickedSpawner = BatSpawners[Random.Range(0, BatSpawners.Count)];
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

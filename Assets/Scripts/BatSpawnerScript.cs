using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawnerScript : MonoBehaviour
{
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBat()
    {
        Instantiate(spawnObject, transform.position + transform.forward * 1.5f, Quaternion.identity);
    }
}

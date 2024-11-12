using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableSpawner : MonoBehaviour
{
    public static CollectableSpawner instance {get; private set;}
    public GameObject collectable;
    public GameObject[] platforms;
    [SerializeField] GameObject pickedPlatform;
    [SerializeField] float pickedCoordinate;

    public TMP_Text pointsText;
    [SerializeField] int points = -1;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCollectable()
    {
        pickedPlatform = platforms[Random.Range(0, platforms.Length)];
        float platformLength = pickedPlatform.transform.localScale.z * 0.5f;
        pickedCoordinate = Random.Range(-platformLength, platformLength);

        Instantiate(collectable,
                    new Vector3(0f, pickedPlatform.transform.position.y + 1.5f, pickedPlatform.transform.position.z + pickedCoordinate),
                    Quaternion.identity);

        points++;
        pointsText.SetText("Points: " + points);
    }
}

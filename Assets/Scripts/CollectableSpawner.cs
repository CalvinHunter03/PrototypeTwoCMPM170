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
    [SerializeField] float pickedCoordinateX;
    [SerializeField] float pickedCoordinateZ;

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
        if(platforms.Length > 1)
        {
            pickedPlatform = platforms[Random.Range(0, platforms.Length)];
            float platformLength = pickedPlatform.transform.localScale.z * 0.5f;
            pickedCoordinateX = 0f;
            pickedCoordinateZ = Random.Range(-platformLength, platformLength);

            Instantiate(collectable,
                        new Vector3(pickedCoordinateX, pickedPlatform.transform.position.y + 1.5f, pickedPlatform.transform.position.z + pickedCoordinateZ),
                        Quaternion.identity);
        }
        else
        {
            float platformLengthX = platforms[0].transform.localScale.x * 0.5f;
            float platformLengthZ = platforms[0].transform.localScale.z * 0.5f;
            pickedCoordinateX = Random.Range(-platformLengthX, platformLengthX);
            pickedCoordinateZ = Random.Range(-platformLengthZ, platformLengthZ);

            Instantiate(collectable,
                        new Vector3(platforms[0].transform.position.x + pickedCoordinateX,
                                    platforms[0].transform.position.y + 1.5f,
                                    platforms[0].transform.position.z + pickedCoordinateZ),
                        Quaternion.identity);
        }

        points++;
        pointsText.SetText("Points: " + points);
    }
}

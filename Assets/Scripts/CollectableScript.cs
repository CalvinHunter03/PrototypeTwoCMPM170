using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public float blastRadius;
    public LayerMask layerMask;
    public static GameObject coinSound;
    public AudioSource coinAudio;
    RaycastHit[] hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        coinSound = GameObject.Find("coinSound");
        coinAudio = coinSound.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.CompareTag("Player"))
        {
            hit = Physics.SphereCastAll(transform.position, blastRadius, transform.forward, layerMask);

            foreach(RaycastHit hitObject in hit)
            {
                if(hitObject.transform.CompareTag("Bat"))
                {
                    Destroy(hitObject.transform.gameObject);
                }
            }
            // Play the coin sound when a "Bat" is found
            coinAudio.Play();

            CollectableSpawner.instance.SpawnCollectable();

            Destroy(this.gameObject);
        }
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, blastRadius);
    // }
}

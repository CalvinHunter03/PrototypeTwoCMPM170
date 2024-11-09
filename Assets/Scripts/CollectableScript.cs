using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public float blastRadius;
    public LayerMask layerMask;
    RaycastHit[] hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        hit = Physics.SphereCastAll(transform.position, blastRadius, transform.forward, layerMask);

        foreach(RaycastHit hitObject in hit)
        {
            if(hitObject.transform.CompareTag("Bat"))
            {
                Destroy(hitObject.transform.gameObject);
            }
        }

        CollectableSpawner.instance.SpawnCollectable();

        Destroy(this.gameObject);
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, blastRadius);
    // }
}

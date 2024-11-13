using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public float blastRadius;
    public LayerMask layerMask;
    [SerializeField] private AudioClip collectCollectable;
    [SerializeField] private AudioClip batDeath;
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
        if (collider.transform.CompareTag("Player"))
        {
            hit = Physics.SphereCastAll(transform.position, blastRadius, transform.forward, layerMask);

            foreach (RaycastHit hitObject in hit)
            {
                if (hitObject.transform.CompareTag("Bat"))
                {
                    SoundFxManager.instance.PlaySoundFXClip(batDeath, transform, 0.8f);
                    Destroy(hitObject.transform.gameObject);
                }
            }

            CollectableSpawner.instance.SpawnCollectable();
            SoundFxManager.instance.PlaySoundFXClip(collectCollectable, transform, 0.8f);

            Destroy(this.gameObject);
        }
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, blastRadius);
    // }
}

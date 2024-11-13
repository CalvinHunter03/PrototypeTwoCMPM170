using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
    private Rigidbody rb;
    public float updateDelay;
    public static GameObject batSound;
    public AudioSource batAudio;
    [SerializeField] float updateTimer;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize audio components
        GameObject batSound = GameObject.Find("batSound");
        if (batSound != null)
        {
            batAudio = batSound.GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GameObject.Find("CapsulePlayer"))
        {
            target = GameObject.Find("CapsulePlayer").transform;
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (Time.time > updateTimer)
        {
            this.transform.LookAt(target);
            updateTimer = Time.time + updateDelay;
        }

        rb.velocity = transform.forward * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (batAudio != null)
            {
                batAudio.Play();
            }
            Destroy(collision.gameObject);
        }

    }
}


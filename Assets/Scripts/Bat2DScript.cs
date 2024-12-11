using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat2DScript : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] bool movingBackwards = false;
    private Rigidbody rb;
    public static GameObject batSound;
    public AudioSource batAudio;
    
    void Awake()
    {
        // Initialize audio components
        GameObject batSound = GameObject.Find("batSound");
        if (batSound != null)
        {
            batAudio = batSound.GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward;
        if(movingBackwards)
        {
            moveDirection *= -1f;
        }
        rb.velocity = moveDirection * moveSpeed;
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
        else if(collision.transform.CompareTag("Wall"))
        {
            movingBackwards = !movingBackwards;
        }
    }
}

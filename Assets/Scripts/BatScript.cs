using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
    private Rigidbody rb;
    public float updateDelay;
    [SerializeField] float updateTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("CapsulePlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(Time.time > updateTimer)
        {
            this.transform.LookAt(target);
            updateTimer = Time.time + updateDelay;
        }

        rb.velocity = transform.forward * moveSpeed;
    }
}

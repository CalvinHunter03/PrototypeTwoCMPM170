using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider chargeSlider;
    public Transform cameraObject;

    public float chargePower;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            chargeSlider.value += Time.deltaTime;
        }
        if(Input.GetMouseButtonUp(0))
        {
            rb.AddForce(cameraObject.forward * chargeSlider.value * chargePower, ForceMode.Impulse);
            chargeSlider.value = 0;
        }

        if(Input.GetKeyDown("space"))
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
    }
}

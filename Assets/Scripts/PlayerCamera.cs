using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraObject;

    public float sensitivity;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    [SerializeField] float rotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        cameraObject.localEulerAngles = Vector3.right * rotation;
    }
}

using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of camera rotation
    public float horizontalInput; // Input for horizontal rotation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        // Rotate the camera around the Y-axis based on horizontal input
        transform.Rotate(Vector3.up, this.horizontalInput * this.rotationSpeed * Time.deltaTime);
    }
}

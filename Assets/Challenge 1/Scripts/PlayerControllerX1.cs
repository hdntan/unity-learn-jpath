using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX1 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per framef
    void FixedUpdate()
    {
        // get the user's vertical input
        this.verticalInput = Input.GetAxis("Vertical");
  

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * this.speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * this.rotationSpeed * Time.fixedDeltaTime * this.verticalInput);

       
    }
}

using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public float forwardInput;
    public float Speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        //Physics.gravity *= 1.5f; // Adjust gravity if needed
        this.focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        this.forwardInput = Input.GetAxis("Vertical");
        this.playerRb.AddForce(this.focalPoint.transform.forward * this.forwardInput * this.Speed);
    }
}

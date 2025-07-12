using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public GameObject focalPoint; // Reference to the focal point
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.focalPoint = GameObject.Find("Focal Point");
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.focalPoint.transform.position + this.focalPoint.transform.forward * 2.0f;
        transform.rotation = Quaternion.LookRotation(this.focalPoint.transform.forward)* Quaternion.Euler(90, 0, 0);
    }
}

using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public GameObject focalPoint; // Reference to the focal point
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(this.focalPoint.transform.forward,  Time.deltaTime * 10f);
    }
}

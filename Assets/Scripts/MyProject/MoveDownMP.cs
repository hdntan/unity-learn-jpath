using UnityEngine;

public class MoveDownMP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody objectRb;
    public float speed = 20.0f;
    public float zRange = -18.0f;
    void Start()
    {
        this.objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.objectRb.AddForce(Vector3.forward * -this.speed ); // Move the object downwards
     if(transform.position.z < this.zRange)
        {
            Destroy(gameObject); // Destroy the object when it goes below the zRange
        }
    }


    
   
}

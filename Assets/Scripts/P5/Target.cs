
using UnityEngine;


public class Target : MonoBehaviour
{
    public Rigidbody targetRb;
    public float minSpeed = 12.0f;
    public float maxSpeed = 16.0f;
    public float maxTorque = 10.0f;
    public float xRange = 4.0f;
    public float ySpawnPos = -2.0f;
    void Start()
    {
        this.targetRb = GetComponent<Rigidbody>();
        this.targetRb.AddForce(this.RandomForce(), ForceMode.Impulse);
        this.targetRb.AddTorque(this.RandomTorque(), this.RandomTorque(), this.RandomTorque(), ForceMode.Impulse);
        transform.position = this.RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(this.minSpeed, this.maxSpeed);
    }

    protected virtual float RandomTorque()
    {
        return Random.Range(-this.maxTorque, this.maxTorque);
    }

    protected virtual Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-this.xRange, this.xRange), this.ySpawnPos);
    }
    
    protected virtual void OnMouseDown()
    {
        Destroy(gameObject); // Destroy the target on mouse click
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject); // Destroy the target on collision
    }
}

using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float topBound = 30f;
    public float lowerBound = -10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > this.topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < this.lowerBound)
        {
             Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        
    }
}

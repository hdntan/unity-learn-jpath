using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
    }
}

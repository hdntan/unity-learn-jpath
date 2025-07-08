using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float repeatWidth;
    void Start()
    {
        this.startPos = transform.position;
        this.repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < this.startPos.x - this.repeatWidth)
        {
            transform.position = this.startPos;
        }
      
    }
}

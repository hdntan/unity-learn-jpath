using UnityEngine;

public class PlayerControllerMP : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody playerRb;
    public float inputHorizontal;
    public float inputVertical;
    public float xRange = 16.0f;
    public float zRange = 9.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();
        this.ConstrainPlayerPosition();

    }

    protected virtual void MovePlayer()
    {
        this.inputHorizontal = Input.GetAxis("Horizontal");
        this.inputVertical = Input.GetAxis("Vertical");
        //  transform.Translate(Vector3.right * this.inputHorizontal * this.speed * Time.deltaTime);
        //  transform.Translate(Vector3.forward * this.inputVertical * this.speed * Time.deltaTime);
        this.playerRb.AddForce(Vector3.right * this.inputHorizontal * this.speed);
        this.playerRb.AddForce(Vector3.forward * this.inputVertical * this.speed);

   
    }

    protected virtual void ConstrainPlayerPosition()
    {

        // if (transform.position.x < -this.xRange)
        // {
        //     transform.position = new Vector3(-this.xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.x > this.xRange)
        // {
        //     transform.position = new Vector3(this.xRange, transform.position.y, transform.position.z);
        // }
        if (transform.position.z < -this.zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -this.zRange);
        }
        if (transform.position.z > this.zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, this.zRange);
        }
    }
}
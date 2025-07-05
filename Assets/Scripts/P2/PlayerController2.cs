using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float inputHorizontal;
    public float inputVertical;

    public float speed = 10f;

    public float xRange = 10f;

    public GameObject projectilePrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.Moving();
        this.AbilityLaunchFood();
    }

    protected virtual void Moving()
    {
        if (transform.position.x < -this.xRange)
        {
            transform.position = new Vector3(-this.xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > this.xRange)
        {
            transform.position = new Vector3(this.xRange, transform.position.y, transform.position.z);
        }
        this.inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * this.inputHorizontal * this.speed * Time.deltaTime);
    }

    protected virtual void AbilityLaunchFood()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(this.projectilePrefab, transform.position, this.projectilePrefab.transform.rotation);

        }
    }
}

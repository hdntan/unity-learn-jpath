using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   public float speed = 30f;

   public float leftBound = -15f;
    public PlayerController3 playerController;
    void Start()
    {
        this.playerController = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * this.speed * Time.deltaTime);

        }
        
        if(transform.position.x < this.leftBound && this.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

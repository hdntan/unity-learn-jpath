using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy
    public Rigidbody enemyRb; // Reference to the Rigidbody component

    public GameObject player; // Reference to the player GameObject
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.enemyRb = GetComponent<Rigidbody>();
        this.player = GameObject.Find("Player"); // Assuming the player GameObject is named "
    }

    // Update is called once per frame
    void Update()
    {
        this.AttackPlayer(); // Call the method to attack the player
        this.DeleteEnemy(); // Call the method to delete the enemy if it falls below a certain height
    }

    protected virtual void AttackPlayer()
    {
        Vector3 lookDirection = (this.player.transform.position - transform.position).normalized;
        this.enemyRb.AddForce(lookDirection * this.speed);
    }
    
    protected virtual void DeleteEnemy()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject); // Destroy the enemy if it falls below a certain height
        }
    }
}

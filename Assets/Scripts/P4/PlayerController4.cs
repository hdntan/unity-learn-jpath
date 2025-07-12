
using UnityEngine;
using System.Collections;

public class PlayerController4 : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerupIndicator;


    public float forwardInput;
    public float Speed = 10f;

  

    public float powerupStrength = 15f; // Strength of the power-up effect

    public bool hasPowerup = false; // Flag to check if the player has a power-up
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        //Physics.gravity *= 1.5f; // Adjust gravity if needed
        this.focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        this.forwardInput = Input.GetAxis("Vertical");
        this.playerRb.AddForce(this.focalPoint.transform.forward * this.forwardInput * this.Speed);
        this.powerupIndicator.transform.position = this.transform.position + new Vector3(0, -0.5f, 0); // Position the power-up indicator below the player
   
        // Cập nhật hướng của directionPoint theo hướng forward của focalPoint (camera)
      
    }



    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            this.hasPowerup = true; // Set the flag to true when the player collects a power-up
            Destroy(other.gameObject); // Destroy the power-up object
            this.powerupIndicator.SetActive(true); // Activate the power-up indicator
            Debug.Log("Power-up collected!");
            StartCoroutine(PowerupCountdownRoutine()); // Start the countdown for the power-up  
        }
    }
    
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Wait for 7 seconds
        this.hasPowerup = false; // Reset the power-up flag
        this.powerupIndicator.SetActive(false); // Deactivate the power-up indicator
        Debug.Log("Power-up has expired!");
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && this.hasPowerup)
        {
            // If the player has a power-up, destroy the enemy

            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - this.transform.position;
            enemyRb.AddForce(awayFromPlayer * this.powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + other.gameObject.name + " with power-up set to " + this.hasPowerup);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // If the player collides with an enemy without a power-up, handle it accordingly
            Debug.Log("Player collided with an enemy without a power-up!");
        }
    }
}

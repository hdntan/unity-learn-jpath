using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    private Vector3 offset_1 = new Vector3(0, 5, -7); // Offset from the player position
    private Vector3 offset_2 = new Vector3(0, 2.5f, 0.5f); // Offset from the player position

    public Vector3 currentOffset; // Current offset to use

    // Dùng để biết đang ở offset nào
    public bool isUsingOffset1 = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentOffset = this.offset_1; // Initialize with the first offset
    }

    void Update()
    {
        // Check for user input to switch offsets
        if (Input.GetKeyDown(KeyCode.E))
        {
            isUsingOffset1 = !isUsingOffset1;
            currentOffset = isUsingOffset1 ? offset_1 : offset_2;
        }
    }

    // Update is called once per frameee
    void LateUpdate()
    {
        
        //offset the camera position to follow the player
        transform.position = this.player.transform.position + this.currentOffset;
    }
}

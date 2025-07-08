using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;

    public PlayerController3 playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerController = GameObject.Find("Player").GetComponent<PlayerController3>();
        InvokeRepeating("SpawnObstacle", this.startDelay, this.repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void SpawnObstacle()
    {
        if (this.playerController.gameOver == false)
        {
            Instantiate(this.obstaclePrefab, this.spawnPos, this.obstaclePrefab.transform.rotation);

        }
    }
}

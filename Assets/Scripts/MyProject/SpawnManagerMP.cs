using UnityEngine;

public class SpawnManagerMP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] prefabEnemies;
    public GameObject prefabPowerup;

    public float spawnRangeX = 12.0f;
    public float spawnRangeZ = 10.0f;

    public int enemyCount;
    void Start()
    {

        InvokeRepeating("SpawnEnemies", 1.0f, 2.0f); // Spawn powerups every 5 seconds
    }

    // Update is called once per frame
    void Update()
    {
        //  this.enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        // if (this.enemyCount == 0)
        // {
        //     this.SpawnPowerup();
        //  } // Spawn a new wave of enemies if there are no enemies left
    }

    protected virtual void SpawnEnemies()
    {
        for (int i = 0; i < this.prefabEnemies.Length; i++)
        {
            int enemyIndex = Random.Range(0, this.prefabEnemies.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-this.spawnRangeX, this.spawnRangeX), 0.5f, this.spawnRangeZ);
            GameObject newEnemy = Instantiate(this.prefabEnemies[enemyIndex], spawnPosition, this.prefabEnemies[enemyIndex].transform.rotation);

        }
    }
    
    protected virtual void SpawnPowerup()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-this.spawnRangeX, this.spawnRangeX), 0.5f,Random.Range(-8, 8));
        Instantiate(this.prefabPowerup, spawnPosition, this.prefabPowerup.transform.rotation);
    }
}

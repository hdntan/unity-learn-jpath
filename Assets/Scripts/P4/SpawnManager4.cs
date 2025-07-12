using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public GameObject powerupPrefab ; // Prefab for the power-up

    public float spawnRange = 9f; // Range for spawning enemies on the X-axis
    public int enemyCount; // Total number of enemies to spawn

    public int waveNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(this.powerupPrefab, GenerateSpawnPosition(), this.powerupPrefab.transform.rotation); // Spawn a power-up at a random position
        this.SpawnEnemyWave(this.waveNumber); // Spawn the first wave of enemies
       
    }

    // Update is called once per frame
    void Update()
    {
        this.enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (this.enemyCount == 0)
        {
            Instantiate(this.powerupPrefab, GenerateSpawnPosition(), this.powerupPrefab.transform.rotation); // Spawn a new power-up when all enemies are defeated
            this.waveNumber++; // Increment the wave number
            Debug.Log("Wave Number: " + this.waveNumber); // Log the current wave number
            this.SpawnEnemyWave(this.waveNumber); // Spawn a new wave of enemies based on the current wave number
         } // Spawn a new wave of enemies if there are no enemies left
    }

    protected virtual void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Generate a random spawn position within the defined range
        Vector3 spawnPosition = GenerateSpawnPosition();

        // Instantiate the enemy prefab at the generated position with no rotation
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(this.enemyPrefabs[0], spawnPosition, this.enemyPrefabs[0].transform.rotation);
        }

    }

    protected virtual Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-this.spawnRange, this.spawnRange);
        float spawnPosZ = Random.Range(-this.spawnRange, this.spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

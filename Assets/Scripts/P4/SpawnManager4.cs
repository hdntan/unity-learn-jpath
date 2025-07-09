using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn

    public float spawnRange = 9f; // Range for spawning enemies on the X-axis
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        Instantiate(this.enemyPrefabs[0], this.GenerateSpawnPosition(), this.enemyPrefabs[0].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    protected virtual Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-this.spawnRange, this.spawnRange);
        float spawnPosZ = Random.Range(-this.spawnRange, this.spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public int animalIndex;

    public float spawnRangeX = 20f;
    public float spawnPosZ = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.S))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-this.spawnRangeX, this.spawnRangeX), 0, this.spawnPosZ);
             this.animalIndex = Random.Range(0, this.animalPrefabs.Length);
            Instantiate(this.animalPrefabs[this.animalIndex], spawnPos, this.animalPrefabs[this.animalIndex].transform.rotation);
        }
    }
}

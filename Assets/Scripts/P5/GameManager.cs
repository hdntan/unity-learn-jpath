using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.spawnRate);
            int randomIndex = Random.Range(0, this.targets.Count);
            GameObject target = Instantiate(this.targets[randomIndex]);
            //target.transform.position = new Vector3(Random.Range(-4, 4), -6, 0);
        }
    }
    
}

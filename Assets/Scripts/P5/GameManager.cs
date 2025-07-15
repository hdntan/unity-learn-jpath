using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.titleScreen = GameObject.Find("TitleScreen");
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(int difficulty)
    {
        this.titleScreen.SetActive(false); // Hide the title screen when the game starts
        this.spawnRate /= difficulty; // Adjust spawn rate based on difficulty
         this.isGameActive = true;
        this.score = 0;
        this.UpdateScore(0); // Initialize score display
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (this.isGameActive)
        {
            yield return new WaitForSeconds(this.spawnRate);
            int randomIndex = Random.Range(0, this.targets.Count);
            GameObject target = Instantiate(this.targets[randomIndex]);

            //target.transform.position = new Vector3(Random.Range(-4, 4), -6, 0);
        }
    }

    public virtual void UpdateScore(int scoreToAdd)
    {
        this.score += scoreToAdd;
        this.scoreText.text = "Score: " + this.score;
    }

    public virtual void GameOver()
    {
        this.gameOverText.gameObject.SetActive(true);
        this.restartButton.gameObject.SetActive(true);
        this.isGameActive = false;

    }

    public virtual void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
    
}

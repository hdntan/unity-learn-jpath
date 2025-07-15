using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button difficultyButton;
    public GameManager gameManager;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.difficultyButton = GetComponent<Button>();
        this.difficultyButton.onClick.AddListener(SetDifficulty); // Register the SetDifficulty method to the button click event
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetDifficulty()
    {
        this.gameManager.StartGame(this.difficulty); // Call StartGame method in GameManager
    }
}

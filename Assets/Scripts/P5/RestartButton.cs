using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.restartButton = GetComponent<Button>();
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
 this.restartButton.onClick.AddListener(OnRestartButtonClicked); // Đăng ký sự kiện onClick

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void OnRestartButtonClicked()
    {
      this.gameManager.RestartGame(); // Call RestartGame method in GameManager
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager> {
    [SerializeField]
    private GameObject gameOverContainer;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private Button restartButton;

    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    public void GameOver() {
        gameOverContainer.SetActive(true);
        _isGameOver = true;
    }

    private void Awake() {
        restartButton.onClick.AddListener(OnClickRestartButton);
    }

    private void OnClickRestartButton() {
        SceneManager.LoadScene("MainScene");
    }
}

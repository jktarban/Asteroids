using Pool;
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

    private GameState _state;

    public GameState State => _state;

    public void GameOver() {
        gameOverContainer.SetActive(true);
        _state = GameState.GameOver;
        scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
    }

    private void Start() {
        restartButton.onClick.AddListener(OnClickRestartButton);
    }

    private void OnClickRestartButton() {
        PoolManager.Clear();
        SceneManager.LoadScene("MainScene");
    }
}

public enum GameState {
    Intro,
    Start,
    GameOver
}

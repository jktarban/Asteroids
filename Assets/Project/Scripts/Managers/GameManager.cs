using Pool;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager> {
    [SerializeField]
    private GameObject gameOverContainer;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private PlayableDirector introTimeline;

    private GameState _state;

    public GameState State => _state;

    public void GameOver() {
        gameOverContainer.SetActive(true);
        _state = GameState.GameOver;
        scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
    }

    private IEnumerator Start() {
        restartButton.onClick.AddListener(OnClickRestartButton);
        yield return new WaitForSeconds((float)introTimeline.duration);
        _state = GameState.Start;
        yield return AsteroidManager.Instance.SpawnNewAsteroidRoutine();
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

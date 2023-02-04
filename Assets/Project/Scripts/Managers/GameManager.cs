using Asteroid;
using Pool;
using Powerup;
using Score;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

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

    public GameState State {
        get {
            return _state;
        }
        set {
            _state = value;

            if (_state == GameState.Start) {
                StartCoroutine(PowerupManager.Instance.SpawnPowerUpRoutine());
            }
        }
    }

    public void GameOver() {
        gameOverContainer.SetActive(true);
        _state = GameState.GameOver;
        scoreText.text = ScoreManager.Instance.ScoreValue.ToString();
    }

    private IEnumerator Start() {
        restartButton.onClick.AddListener(OnClickRestartButton);
        yield return new WaitForSeconds((float)introTimeline.duration);
        _state = GameState.WaitForInput;
        StartCoroutine(AsteroidManager.Instance.SpawnNewAsteroidRoutine());
    }

    private void OnClickRestartButton() {
        PoolManager.Clear();
        SceneManager.LoadScene("MainScene");
    }
}

public enum GameState {
    Intro,
    WaitForInput,
    Start,
    GameOver
}

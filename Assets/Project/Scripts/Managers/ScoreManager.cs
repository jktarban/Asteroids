using TMPro;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager> {
    [SerializeField]
    private TMP_Text scoreText;

    private int _scoreValue;

    public void AddScore() {
        _scoreValue++;
        scoreText.text = _scoreValue.ToString();
    }
}

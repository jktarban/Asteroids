using TMPro;
using UnityEngine;
using Utils;

namespace Score {
    public class ScoreManager : MonoSingleton<ScoreManager> {
        [SerializeField]
        private TMP_Text scoreText;

        private int _scoreValue;

        public int ScoreValue => _scoreValue;

        public void AddScore() {
            _scoreValue++;
            scoreText.text = _scoreValue.ToString();
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoSingleton<HealthManager> {
    [SerializeField]
    private PlayerSO playerSettings;
    [SerializeField]
    private Image healthFillImage;

    private int _healthValue;
    private bool _isRecovering;

    internal void Hit() {
        if (_isRecovering) {
            return;
        }

        StartCoroutine(HitRoutine());
    }

    private void Start() {
        _healthValue = playerSettings.Health;
        healthFillImage.fillAmount = 1f;
    }

    private IEnumerator HitRoutine() {
        if (GameManager.Instance.State != GameState.Start) {
            yield break;
        }

        _isRecovering = true;
        DeductHealth();
        yield return new WaitForSeconds(playerSettings.HitRecoveryTime);
        _isRecovering = false;
    }

    private void DeductHealth() {
        _healthValue--;
        healthFillImage.fillAmount = (float)_healthValue / (float)playerSettings.Health;

        if (_healthValue == 0) {
            GameManager.Instance.GameOver();
        }
    }
}

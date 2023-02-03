using System.Collections;
using UnityEngine;

public class HitComponent : MonoBehaviour
{
    private PlayerSO _playerSettings;
    private bool _isRecovering;

    internal void SetPlayerSettings(PlayerSO playerSettings) {
        _playerSettings = playerSettings;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asteroid")) {
            if (_isRecovering) {
                return;
            }

            StartCoroutine(HitRoutine());
        }
    }

    private IEnumerator HitRoutine() {
        if (GameManager.Instance.IsGameOver) {
            yield break;
        }

        _isRecovering = true;
        HealthManager.Instance.DeductHealth();
        yield return new WaitForSeconds(_playerSettings.HitRecoveryTime);
        _isRecovering = false;
    }
}

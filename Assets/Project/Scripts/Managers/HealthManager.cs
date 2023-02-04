using Barrier;
using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Health {
    public class HealthManager : MonoSingleton<HealthManager> {
        [SerializeField]
        private PlayerSO playerSettings;
        [SerializeField]
        private Image healthFillImage;

        private int _healthValue;
        private bool _isRecovering;
        private BarrierController _barrierController;

        internal void SetBarrier(BarrierController barrierController) {
            _barrierController = barrierController;
        }

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

            if (!IsUsingBarrier()) {
                DeductHealth();
            }

            _isRecovering = true;
            yield return new WaitForSeconds(playerSettings.HitRecoveryTime);
            _isRecovering = false;
        }

        private bool IsUsingBarrier() {
            if (_barrierController is object) {
                if (_barrierController != null) {
                    if (_barrierController.AbsorbAmount != 0) {
                        _barrierController.UseBarrier();
                        return true;
                    }
                }
            }

            return false;
        }

        private void DeductHealth() {
            _healthValue--;
            healthFillImage.fillAmount = (float)_healthValue / (float)playerSettings.Health;

            if (_healthValue == 0) {
                GameManager.Instance.GameOver();
            }
        }
    }
}

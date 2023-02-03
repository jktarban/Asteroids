using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour {
        private Rigidbody2D _rigidbody2D;
        private float _moveSpeed;
        private float _rotationSpeed;
        private PlayerSO _playerSettings;

        internal void SetPlayerSettings(PlayerSO playerSettings) {
            _playerSettings = playerSettings;
        }

        internal void OnAccelerate(InputAction.CallbackContext context) {
            _moveSpeed = context.ReadValue<float>();
        }

        internal void OnRotation(InputAction.CallbackContext context) {
            _rotationSpeed = context.ReadValue<float>();
        }

        private void FixedUpdate() {
            if (GameManager.Instance.IsGameOver) {
                gameObject.SetActive(false);
                return;
            }

            if (_playerSettings == null) {
                return;
            }

            var direction = (Vector2)transform.up;
            _rigidbody2D.AddForce(_moveSpeed * _playerSettings.AccelerationSpeed * Time.fixedDeltaTime * direction, ForceMode2D.Impulse);
            _rigidbody2D.velocity = Vector3.ClampMagnitude(_rigidbody2D.velocity, _playerSettings.AccelerationSpeed);
            _rigidbody2D.rotation -= _rotationSpeed * _playerSettings.RotationSpeed;
        }

        private void Awake() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}

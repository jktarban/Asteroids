using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour {
        [SerializeField]
        private PlayerSO playerSettings;

        private Rigidbody2D _rigidbody2D;
        private bool _isAccelerating;
        private float _moveSpeed;
        private float _rotationSpeed;

        internal void OnAccelerate(InputAction.CallbackContext context) {
            _moveSpeed = context.ReadValue<float>() * playerSettings.AccelerationSpeed;
        }

        internal void OnRotation(InputAction.CallbackContext context) {
            _rotationSpeed = context.ReadValue<float>() * playerSettings.RotationSpeed;
        }

        internal void Fire(InputAction.CallbackContext context) {

        }

        private void FixedUpdate() {
            var direction = (Vector2)transform.up;
            _rigidbody2D.AddForce(_moveSpeed * Time.fixedDeltaTime * direction, ForceMode2D.Impulse);
            _rigidbody2D.velocity = Vector3.ClampMagnitude(_rigidbody2D.velocity, playerSettings.AccelerationSpeed);
            _rigidbody2D.rotation -= _rotationSpeed;
        }

        private void Awake() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}

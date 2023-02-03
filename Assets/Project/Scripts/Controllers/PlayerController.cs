using Movement;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(MovementComponent))]
    public class PlayerController : MonoBehaviour, IScreenBounds {
  
        private MovementComponent _movementComponent;

        private void Awake() {
            _movementComponent = GetComponent<MovementComponent>();
            SetInput();
        }

        private void SetInput() {
            var playerInputAction = new PlayerInputAction();
            playerInputAction.Enable();
            playerInputAction.Player.Acceleration.performed += _movementComponent.Accelerate;
            playerInputAction.Player.Rotation.performed += _movementComponent.Rotation;
            playerInputAction.Player.Fire.performed += _movementComponent.Fire;
        }
    }
}

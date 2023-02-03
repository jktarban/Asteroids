using Movement;
using UnityEngine;
using Weapon;

namespace Player {
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    public class PlayerController : MonoBehaviour, IScreenBounds {

        private MovementComponent _movementComponent;
        private WeaponComponent _weaponComponent;

        private void Awake() {
            _movementComponent = GetComponent<MovementComponent>();
            _weaponComponent = GetComponent<WeaponComponent>();
            SetInput();
        }

        private void SetInput() {
            var playerInputAction = new PlayerInputAction();
            playerInputAction.Enable();
            playerInputAction.Player.Acceleration.performed += _movementComponent.OnAccelerate;
            playerInputAction.Player.Rotation.performed += _movementComponent.OnRotation;
            playerInputAction.Player.Fire.performed += _weaponComponent.OnFire;
        }
    }
}

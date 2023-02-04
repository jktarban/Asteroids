using Movement;
using UnityEngine;
using Weapon;

namespace Player {
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    [RequireComponent(typeof(CollideComponent))]
    public class PlayerController : MonoBehaviour, IScreenBounds {
        [SerializeField]
        private PlayerSO playerSettings;
        private MovementComponent _movementComponent;
        private WeaponComponent _weaponComponent;
        private CollideComponent _hitComponent;
        private PlayerInputAction _playerInputAction;

        private void Awake() {
            SetComponents();
            SetInput();
        }

        private void SetInput() {
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.Enable();
            _playerInputAction.Player.Acceleration.performed += _movementComponent.OnAccelerate;
            _playerInputAction.Player.Rotation.performed += _movementComponent.OnRotation;
            _playerInputAction.Player.Fire.performed += _weaponComponent.OnFire;
        }

        private void SetComponents() {
            _movementComponent = GetComponent<MovementComponent>();
            _weaponComponent = GetComponent<WeaponComponent>();
            _hitComponent = GetComponent<CollideComponent>();

            _movementComponent.SetPlayerSettings(playerSettings);
            _hitComponent.SetPlayerSettings(playerSettings);
        }

        private void OnDestroy() {
            _playerInputAction.Player.Acceleration.performed -= _movementComponent.OnAccelerate;
            _playerInputAction.Player.Rotation.performed -= _movementComponent.OnRotation;
            _playerInputAction.Player.Fire.performed -= _weaponComponent.OnFire;
        }
    }
}

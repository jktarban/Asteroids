using Movement;
using UnityEngine;
using Weapon;

namespace Player {
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    [RequireComponent(typeof(HitComponent))]
    public class PlayerController : MonoBehaviour, IScreenBounds {
        [SerializeField]
        private PlayerSO playerSettings;
        private MovementComponent _movementComponent;
        private WeaponComponent _weaponComponent;
        private HitComponent _hitComponent;

        private void Awake() {
            SetComponents();
            SetInput();
        }

        private void SetInput() {
            var playerInputAction = new PlayerInputAction();
            playerInputAction.Enable();
            playerInputAction.Player.Acceleration.performed += _movementComponent.OnAccelerate;
            playerInputAction.Player.Rotation.performed += _movementComponent.OnRotation;
            playerInputAction.Player.Fire.performed += _weaponComponent.OnFire;
        }

        private void SetComponents() {
            _movementComponent = GetComponent<MovementComponent>();
            _weaponComponent = GetComponent<WeaponComponent>();
            _hitComponent = GetComponent<HitComponent>();

            _movementComponent.SetPlayerSettings(playerSettings);
            _hitComponent.SetPlayerSettings(playerSettings);
        }
    }
}

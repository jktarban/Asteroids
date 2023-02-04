using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapon {
    public class WeaponComponent : MonoBehaviour {
        [SerializeField]
        private Transform weaponHead;
        [SerializeField]
        private WeaponManagerSettingsSO weaponManagerSettings;
        private IWeapon weapon;

        internal void OnFire(InputAction.CallbackContext obj) {
            if (GameManager.Instance.State != GameState.Start) {
                return;
            }

            if (weapon == null) {
                return;
            }

            weapon.Fire();
        }

        public void SetWeapon(string weaponName) {
            if (weapon != null) {
                weapon.EndTimer();
            }

            var weaponSettings = weaponManagerSettings.GetWeaponSettings(weaponName);
            weapon = new BaseWeapon(weaponHead, weaponSettings, OnWeaponTimeOver);
        }

        private void OnEnable() {
            SetWeapon(typeof(WeaponDefault).Name);
        }

        private void OnWeaponTimeOver() {
            SetWeapon(typeof(WeaponDefault).Name);
        }
    }
}

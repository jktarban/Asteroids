using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapon {
    public class WeaponComponent : MonoBehaviour {
        [SerializeField]
        private Transform weaponHead;
        [SerializeField]
        private WeaponSOItem[] weaponSOItems;
        private IWeapon weapon;

        internal void OnFire(InputAction.CallbackContext obj) {
            if(GameManager.Instance.State != GameState.Start) {
                return;
            }

            weapon.Fire();
        }

        public void SetWeapon(Type type) {
            if (weapon != null) {
                weapon.EndTimer();
            }

            var weaponSettings = weaponSOItems.First((WeaponSOItem x) => x.WeaponType.Type == type).WeaponSettings;

            if (type == typeof(WeaponDefault)) {
                weapon = new WeaponDefault(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
            if (type == typeof(WeaponBlaster)) {
                weapon = new WeaponBlaster(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
        }

        private void OnEnable() {
            SetWeapon(typeof(WeaponDefault));
        }

        private void OnWeaponTimeOver() {
            SetWeapon(typeof(WeaponDefault));
        }
    }
}

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
            weapon.Fire();
        }

        private void OnEnable() {
            SetWeapon(typeof(WeaponStart));
        }

        private void OnWeaponTimeOver() {
            SetWeapon(typeof(WeaponStart));
        }

        private void SetWeapon(Type type) {
            if (weapon != null) {
                weapon.EndTimer();
            }

            var weaponSettings = weaponSOItems.First(x => x.WeaponType.Type == type).WeaponSettings;

            if (type == typeof(WeaponStart)) {
                weapon = new WeaponStart(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
            if (type == typeof(WeaponBlaster)) {
                weapon = new WeaponBlaster(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
        }
    }
}

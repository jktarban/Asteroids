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
            if (GameManager.Instance.State != GameState.Start) {
                return;
            }

            weapon.Fire();
        }

        public void SetWeapon(string weaponName) {
            if (weapon != null) {
                weapon.EndTimer();
            }

            var weaponSettings = weaponSOItems.First((WeaponSOItem x) => x.WeaponType.Type.Name == weaponName).WeaponSettings;

            if (weaponName == typeof(WeaponDefault).Name) {
                weapon = new WeaponDefault(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
            if (weaponName == typeof(WeaponBlaster).Name) {
                weapon = new WeaponBlaster(weaponHead, weaponSettings, OnWeaponTimeOver);
            }
        }

        private void OnEnable() {
            SetWeapon(typeof(WeaponDefault).Name);
        }

        private void OnWeaponTimeOver() {
            SetWeapon(typeof(WeaponDefault).Name);
        }
    }
}

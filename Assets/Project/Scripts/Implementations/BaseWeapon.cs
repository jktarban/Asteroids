using System;
using System.Timers;
using UnityEngine;

namespace Weapon {
    public class BaseWeapon : IWeapon {
        protected WeaponSO _weaponSO;
        protected Transform _weaponHead;
        private Action _onWeaponTimeOver;
        private Timer _weaponTimer;

        public BaseWeapon(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) {
            _weaponSO = weaponSO;
            _weaponHead = weaponHead;
            _onWeaponTimeOver = onWeaponTimeOver;

            if (weaponSO.Timer == -1) {
                return;
            }

            _weaponTimer = new Timer();
            _weaponTimer.Elapsed += new ElapsedEventHandler(OnWeaponTimeOver);
            _weaponTimer.Interval = weaponSO.Timer * 1000;
            _weaponTimer.Enabled = true;
        }

        public void EndTimer() {
            if (_weaponTimer != null) {
                _weaponTimer.Stop();
            }
        }

        public void Fire() {
            _weaponSO.CreateBullets(_weaponHead);
        }

        private void OnWeaponTimeOver(object sender, ElapsedEventArgs e) {
            _onWeaponTimeOver?.Invoke();
        }
    }
}

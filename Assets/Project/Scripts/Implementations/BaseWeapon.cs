using Helpers;
using System;
using System.Collections;
using System.Timers;
using UnityEngine;

namespace Weapon {
    public class BaseWeapon : IWeapon {
        protected WeaponSO _weaponSO;
        protected Transform _weaponHead;
        private Action _onWeaponTimeOver;
        private Coroutine _timerRoutine;

        public BaseWeapon(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) {
            _weaponSO = weaponSO;
            _weaponHead = weaponHead;
            _onWeaponTimeOver = onWeaponTimeOver;

            if (weaponSO.Timer == -1) {
                return;
            }

            _timerRoutine = CoroutineHelper.Instance.StartCoroutine(TimerRoutine(_weaponSO.Timer));
        }

        public void EndTimer() {
            if(_timerRoutine != null) {
                CoroutineHelper.Instance.StopCoroutine(_timerRoutine);
            }
        }

        public void Fire() {
            _weaponSO.CreateBullets(_weaponHead);
        }

        private IEnumerator TimerRoutine(float time) {
            yield return new WaitForSeconds(time);
            _onWeaponTimeOver?.Invoke();
        }
    }
}

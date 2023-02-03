using System;
using UnityEngine;

namespace Weapon {
    public class WeaponStart : BaseWeapon {
        public WeaponStart(Transform fireHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(fireHead, weaponSO, onWeaponTimeOver) {
        }

        public override void Fire() {
            Debug.Log("WEAPON START");
        }
    }
}

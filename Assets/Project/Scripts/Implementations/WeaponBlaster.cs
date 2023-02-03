using System;
using UnityEngine;

namespace Weapon {
    public class WeaponBlaster : BaseWeapon {
        public WeaponBlaster(Transform fireHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(fireHead, weaponSO, onWeaponTimeOver) {
        }

        public override void Fire() {
            Debug.Log("WEAPON BLASTER");
        }
    }
}

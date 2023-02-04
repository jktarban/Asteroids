using System;
using UnityEngine;

namespace Weapon {
    public class WeaponBlaster : BaseWeapon {
        public WeaponBlaster(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(weaponHead, weaponSO, onWeaponTimeOver) {
        }
    }
}

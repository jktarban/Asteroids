using System;
using UnityEngine;

namespace Weapon {
    public class WeaponStart : BaseWeapon {
        public WeaponStart(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(weaponHead, weaponSO, onWeaponTimeOver) {
        }
    }
}

using System;
using UnityEngine;

namespace Weapon {
    public class WeaponDefault : BaseWeapon {
        public WeaponDefault(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(weaponHead, weaponSO, onWeaponTimeOver) {}
    }
}

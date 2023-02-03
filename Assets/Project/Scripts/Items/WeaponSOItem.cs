using System;
using TypeReferences;
using UnityEngine;

namespace Weapon {
    [Serializable]
    public class WeaponSOItem {
        [SerializeField]
        [Inherits(typeof(IWeapon))]
        private TypeReference weaponType;
        [SerializeField]
        private WeaponSO weaponSettings;

        public TypeReference WeaponType => weaponType;
        public WeaponSO WeaponSettings => weaponSettings;
    }
}
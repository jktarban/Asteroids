using System;
using UnityEngine;

public class WeaponBlaster : BaseWeapon {
    public WeaponBlaster(Transform fireHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(fireHead, weaponSO, onWeaponTimeOver) {
    }

    public override void Fire() {
        Debug.Log("WEAPON BLASTER");
    }
}

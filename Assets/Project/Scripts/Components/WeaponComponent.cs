using System;
using System.Linq;
using TypeReferences;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponComponent : MonoBehaviour {
    [SerializeField]
    private Transform weaponHead;
    [SerializeField]
    private WeaponSOItem[] weaponSOItems;
    private IWeapon weapon;

    internal void OnFire(InputAction.CallbackContext obj) {
        weapon.Fire();
    }

    private void OnEnable() {
        SetWeapon(typeof(WeaponBlaster));
    }

    private void OnWeaponTimeOver() {
        SetWeapon(typeof(WeaponStart));
    }

    private void SetWeapon(Type type) {
        if(weapon!= null) {
            weapon.EndTimer();
        }
      
        var weaponSettings = weaponSOItems.First(x => x.WeaponType.Type == type).WeaponSettings;
      
        if (type == typeof(WeaponStart)) {
            weapon = new WeaponStart(weaponHead, weaponSettings, OnWeaponTimeOver);
        }
        if (type == typeof(WeaponBlaster)) {
            weapon = new WeaponBlaster(weaponHead, weaponSettings, OnWeaponTimeOver);
        }
    }
}

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

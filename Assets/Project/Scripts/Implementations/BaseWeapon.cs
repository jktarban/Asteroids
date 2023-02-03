using System;
using System.Timers;
using UnityEngine;

public abstract class BaseWeapon : IWeapon {
    protected Transform _weaponHead;
    protected Action _onWeaponTimeOver;
    private Timer _weaponTimer;

    public BaseWeapon(Transform fireHead, WeaponSO weaponSO, Action onWeaponTimeOver) {
        _weaponHead = fireHead;
        _onWeaponTimeOver = onWeaponTimeOver;

        if(weaponSO.Timer == -1) {
            return;
        }

        _weaponTimer = new Timer();
        _weaponTimer.Elapsed += new ElapsedEventHandler(OnWeaponTimeOver);
        _weaponTimer.Interval = weaponSO.Timer * 1000;
        _weaponTimer.Enabled = true;
    }

    public void EndTimer() {
        if(_weaponTimer!= null) {
            _weaponTimer.Stop();
        }
    }

    private void OnWeaponTimeOver(object sender, ElapsedEventArgs e) {
        _onWeaponTimeOver?.Invoke();
    }

    public abstract void Fire();
}

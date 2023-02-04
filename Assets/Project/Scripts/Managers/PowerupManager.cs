using Pool;
using UnityEngine;
using Weapon;

public class PowerupManager : MonoSingleton<PowerupManager>
{
    [SerializeField]
    private PowerupManagerSO powerupSettings;
    [SerializeField]
    private WeaponComponent weaponComponent;
    [SerializeField]
    private BarrierComponent barrierComponent;

    public void CheckPowerup(PowerupController powerupController) {
        var powerupName = powerupController.PowerupName;

        if (powerupName == typeof(WeaponBlaster).Name) {
            weaponComponent.SetWeapon(typeof(WeaponBlaster));
        }

        PoolManager.Recycle(powerupController.gameObject);
    }
}

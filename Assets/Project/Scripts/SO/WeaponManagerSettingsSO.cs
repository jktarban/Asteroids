using System.Linq;
using UnityEngine;

namespace Weapon {
    [CreateAssetMenu(fileName = "WeaponManagerSettings", menuName = "GameSettings/WeaponManagerSettings")]
    public class WeaponManagerSettingsSO : ScriptableObject {
        [SerializeField]
        private WeaponSO[] weaponSettings;

        public WeaponSO GetWeaponSettings(string weaponName) {
            return weaponSettings.First(x => x.name.Contains(weaponName));
        }
    }
}

// Creates a simple wizard that lets you create a Light GameObject
// or if the user clicks in "Apply", it will set the color of the currently
// object selected to red

using Barrier;
using Bullet;
using UnityEditor;
using UnityEngine;
using Weapon;

public class CreatePowerup : ScriptableWizard {
    [SerializeField]
    private string powerupName;
    [SerializeField]
    private PowerupType powerupType;

    private enum PowerupType {
        Weapon,
        Barrier
    }

    [MenuItem("GameObject/CreatePowerup")]
    private static void CreateWizard() {
        DisplayWizard<CreatePowerup>("Create Powerup", "Create");
    }

    private void OnWizardCreate() {
        var powerupPrefabPath = "Assets/Project/Prefabs/Base/BasePowerupPrefab.prefab";
        var powerupvariantPath = "Assets/Project/Prefabs/Powerup/" + powerupName + "PowerupPrefab" + ".prefab";
        CreatePrefab(powerupPrefabPath, powerupvariantPath);

        if (powerupType == PowerupType.Weapon) {
            var bulletPrefabPath = "Assets/Project/Prefabs/Base/BaseBulletPrefab.prefab";
            var bulletVariantPath = "Assets/Project/Prefabs/Bullet/Bullet" + powerupName + "Prefab" + ".prefab";
            CreatePrefab(bulletPrefabPath, bulletVariantPath);

            var bulletSOPath = "Assets/Project/Settings/Bullet/Bullet" + powerupName + "Settings.asset";
            CreateScriptableObjecte<BulletSO>(bulletSOPath);

            var weaponSOPath = "Assets/Project/Settings/Weapon/Weapon" + powerupName + "Settings.asset";
            CreateScriptableObjecte<WeaponSO>(weaponSOPath);
        }
        else if (powerupType == PowerupType.Barrier) {
            var barrierPrefabPath = "Assets/Project/Prefabs/Base/BaseBarrierPrefab.prefab";
            var barrierVariantPath = "Assets/Project/Prefabs/Barrier/Barrier" + powerupName + "Prefab" + ".prefab";
            CreatePrefab(barrierPrefabPath, barrierVariantPath);

            var barrierSOPath = "Assets/Project/Settings/Barrier/Barrier" + powerupName + "Settings.asset";
            CreateScriptableObjecte<BarrierSO>(barrierSOPath);
        }
    }

    private void CreatePrefab(string prefabPath, string variantPath) {
        var powerupPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
        var powerupSource = PrefabUtility.InstantiatePrefab(powerupPrefab) as GameObject;
        PrefabUtility.SaveAsPrefabAsset(powerupSource, variantPath);
        DestroyImmediate(powerupSource);
    }

    private void CreateScriptableObjecte<T>(string path) where T : ScriptableObject {
        var SO = CreateInstance<T>();
        AssetDatabase.CreateAsset(SO, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}


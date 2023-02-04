using Barrier;
using Bullet;
using Powerup;
using System;
using System.IO;
using System.Reflection;
using TypeReferences;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Weapon;

public class CreatePowerup : ScriptableWizard {
    [SerializeField]
    private string powerupName;
    [SerializeField]
    private PowerupType powerupType;

    private const string POWERUP_ASSEMBLY_KEY = "WEAPON_KEY";
    private const string POWERUP_PATH_KEY = "POWERUP_PATH_KEY";
    private enum PowerupType {
        Weapon,
        Barrier
    }

    [DidReloadScripts]
    public static void OnCompileScripts() {
        var weaponKey = EditorPrefs.GetString(POWERUP_ASSEMBLY_KEY, "");

        if (string.IsNullOrEmpty(weaponKey)) {
            return;
        }

        //set reference of powerup to new weapon type
        var assemblyName = "Assembly-CSharp";
        var assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, weaponKey);
        var weaponType = Type.GetType(assemblyQualifiedName);
        var powerupPath = EditorPrefs.GetString(POWERUP_PATH_KEY, "");
        var powerup = AssetDatabase.LoadAssetAtPath<GameObject>(powerupPath).GetComponent<PowerupController>();
        powerup.PowerupType = new TypeReference(weaponType);

        EditorPrefs.SetString(POWERUP_ASSEMBLY_KEY, "");
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
            var bullet = CreatePrefab(bulletPrefabPath, bulletVariantPath);

            var bulletSOPath = "Assets/Project/Settings/Bullet/Bullet" + powerupName + "Settings.asset";
            var bulletSO = CreateScriptableObjecte<BulletSO>(bulletSOPath);

            var weaponSOPath = "Assets/Project/Settings/Weapon/Weapon" + powerupName + "Settings.asset";
            var weaponSO = CreateScriptableObjecte<WeaponSO>(weaponSOPath);

            var weaponScriptPath = "Assets/Project/Scripts/Implementations/Weapon" + powerupName + ".cs";
            if (File.Exists(weaponScriptPath) == false) {
                using StreamWriter outfile =
                new StreamWriter(weaponScriptPath); outfile.WriteLine("using Powerup;");
                outfile.WriteLine("using System;");
                outfile.WriteLine("using UnityEngine;");
                outfile.WriteLine("");
                outfile.WriteLine("");
                outfile.WriteLine("namespace Weapon {");
                outfile.WriteLine("public class Weapon" + powerupName + " : BaseWeapon, IPowerup {");
                outfile.WriteLine("public Weapon" + powerupName + "(Transform weaponHead, WeaponSO weaponSO, Action onWeaponTimeOver) : base(weaponHead, weaponSO, onWeaponTimeOver) { }");
                outfile.WriteLine("}");
                outfile.WriteLine("}");
                outfile.WriteLine("");
            }

            bullet.GetComponent<BulletController>().BulletSettings = bulletSO;
            weaponSO.BulletPrefab = bullet.GetComponent<BulletController>();
            EditorPrefs.SetString(POWERUP_ASSEMBLY_KEY, "Weapon.Weapon" + powerupName);
        }
        else if (powerupType == PowerupType.Barrier) {
            var barrierPrefabPath = "Assets/Project/Prefabs/Base/BaseBarrierPrefab.prefab";
            var barrierVariantPath = "Assets/Project/Prefabs/Barrier/Barrier" + powerupName + "Prefab" + ".prefab";
            var barrier = CreatePrefab(barrierPrefabPath, barrierVariantPath);

            var barrierSOPath = "Assets/Project/Settings/Barrier/Barrier" + powerupName + "Settings.asset";
            var barrierSO = CreateScriptableObjecte<BarrierSO>(barrierSOPath);

            var barrierScriptPath = "Assets/Project/Scripts/Implementations/Barrier" + powerupName + ".cs";
            if (File.Exists(barrierScriptPath) == false) {
                using StreamWriter outfile =
                new StreamWriter(barrierScriptPath); outfile.WriteLine("using Powerup;");
                outfile.WriteLine("");
                outfile.WriteLine("namespace Barrier {");
                outfile.WriteLine("public class Barrier" + powerupName + " : BaseBarrier, IPowerup {}");
                outfile.WriteLine("}");
                outfile.WriteLine("");
            }

            barrier.GetComponent<BarrierController>().BarrierSettings = barrierSO;
            EditorPrefs.SetString(POWERUP_ASSEMBLY_KEY, "Barrier.Barrier" + powerupName);
        }

        EditorPrefs.SetString(POWERUP_PATH_KEY, powerupvariantPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
    }

    private GameObject CreatePrefab(string prefabPath, string variantPath) {
        var prefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
        var source = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        var go = PrefabUtility.SaveAsPrefabAsset(source, variantPath);
        DestroyImmediate(source);

        return go;
    }

    private T CreateScriptableObjecte<T>(string path) where T : ScriptableObject {
        var SO = CreateInstance<T>();
        AssetDatabase.CreateAsset(SO, path);

        return SO;
    }
}

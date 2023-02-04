using Pool;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSettings", menuName = "GameSettings/PowerupSettings")]
public class PowerUpSO : ScriptableObject {
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private GameObject[] powerupWeaponPrefabs;
    [SerializeField]
    private GameObject[] powerupBarrierPrefabs;

    public GameObject[] PowerupWeaponPrefabs => powerupWeaponPrefabs;
    public GameObject[] PowerupBarrierPrefabs => powerupBarrierPrefabs;

    public float SpawnInterval => spawnInterval;

    public void CreatePowerup(Vector2 position, Vector2 direction) {
        var randomNumber = Random.Range(0, 2);
        GameObject[] powerupPrefabs;

        if (randomNumber == 0) {
            powerupPrefabs = powerupWeaponPrefabs;
        }
        else {
            powerupPrefabs = powerupBarrierPrefabs;
        }

        var powerupPrefab = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        var powerupObject = PoolManager.Recycle(powerupPrefab.name);

        if (powerupObject == null) {
            powerupObject = Instantiate(powerupPrefab);
        }

        var powerup = powerupObject.GetComponent<PowerupController>();
        powerup.name = powerup.name;
        powerup.SetSpeed(movementSpeed, direction);
        powerup.transform.position = position;
    }
}

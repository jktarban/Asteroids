using Pool;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupManagerSettings", menuName = "GameSettings/PowerupManagerSettings")]
public class PowerUpSO : ScriptableObject {
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private GameObject[] powerupPrefabs;
 

    public float SpawnInterval => spawnInterval;

    public void CreatePowerup(Vector2 position, Vector2 direction) {
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

using Pool;
using UnityEngine;

namespace Powerup {
    [CreateAssetMenu(fileName = "PowerupSettings", menuName = "GameSettings/PowerupSettings")]
    public class PowerUpSO : ScriptableObject {
        [SerializeField]
        private float spawnInterval;
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private PowerupController[] powerupWeaponPrefabs;
        [SerializeField]
        private PowerupController[] powerupBarrierPrefabs;

        public PowerupController[] PowerupWeaponPrefabs => powerupWeaponPrefabs;
        public PowerupController[] PowerupBarrierPrefabs => powerupBarrierPrefabs;

        public float SpawnInterval => spawnInterval;

        public void CreatePowerup(Vector2 position, Vector2 direction) {
            var randomNumber = Random.Range(0, 2);
            PowerupController[] powerupPrefabs;

            if (randomNumber == 0) {
                powerupPrefabs = powerupWeaponPrefabs;
            }
            else {
                powerupPrefabs = powerupBarrierPrefabs;
            }

            var powerupPrefab = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
            var powerupObject = PoolManager.Recycle(powerupPrefab.name);

            if (powerupObject == null) {
                powerupObject = Instantiate(powerupPrefab.gameObject);
            }

            var powerup = powerupObject.GetComponent<PowerupController>();
            powerup.name = powerup.name;
            powerup.SetSpeed(movementSpeed, direction);
            powerup.transform.position = position;
        }
    }
}

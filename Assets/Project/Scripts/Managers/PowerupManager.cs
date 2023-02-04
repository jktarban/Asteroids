using Barrier;
using Player;
using Pool;
using System.Collections;
using UnityEngine;
using Weapon;

public class PowerupManager : MonoSingleton<PowerupManager> {
    [SerializeField]
    private PowerUpSO powerupSettings;
    [SerializeField]
    private WeaponComponent weaponComponent;
    [SerializeField]
    private BarrierComponent barrierComponent;
    private const float POWERUP_DIRECTION = 1f;
    private const float PLAYER_POSITIOM_OFFSET = 10f;

    public void CheckPowerup(PowerupController powerupController) {
        var powerupName = powerupController.PowerupName;

        if (powerupName == typeof(WeaponBlaster).Name) {
            weaponComponent.SetWeapon(typeof(WeaponBlaster));
        }

        if (powerupName == typeof(BarrierBasic).Name) {
            barrierComponent.SetBarrier(typeof(BarrierBasic));
        }

        PoolManager.Recycle(powerupController.gameObject);
    }

    public IEnumerator SpawnPowerUpRoutine() {
        if (GameManager.Instance.State != GameState.Start) {
            yield break;
        }

        //spawn outside player area
        var playerPosition = FindObjectOfType<PlayerController>().transform.position;
        var randomX = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET);
        var randomY = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET);
        var direction = GetRandomDirection();
        yield return new WaitForSeconds(powerupSettings.SpawnInterval);
        powerupSettings.CreatePowerup(new Vector2(randomX, randomY), direction);
        yield return SpawnPowerUpRoutine();
    }

    private Vector2 GetRandomDirection() {
        return new Vector2(Random.Range(-POWERUP_DIRECTION, POWERUP_DIRECTION), Random.Range(-POWERUP_DIRECTION, POWERUP_DIRECTION));
    }
}

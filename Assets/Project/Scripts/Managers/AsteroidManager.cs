using Player;
using Pool;
using System.Collections;
using UnityEngine;

public class AsteroidManager : MonoSingleton<AsteroidManager> {
    [SerializeField]
    private AsteroidSO asteroidManagerSettings;
    private const float ASTEROID_DIRECTION = 1f;
    private const float PLAYER_POSITIOM_OFFSET = 10f;

    public void DestroyAsteroid(AsteroidController asteroidController) {
        var destroySteps = asteroidController.DestroySteps;
        var position = asteroidController.transform.position;
        PoolManager.Pool(asteroidController.gameObject);
        destroySteps--;

        if(destroySteps == 0) {
            ScoreManager.Instance.AddScore();
            return;
        }

        //opposite directions when separate
        var asteroidDirection = GetRandomAsteroidDirection();
        asteroidManagerSettings.CreateAsteroids(destroySteps, position, asteroidDirection);
        asteroidManagerSettings.CreateAsteroids(destroySteps, position, -asteroidDirection);
    }

    private Vector2 GetRandomAsteroidDirection() {
        return new Vector2(Random.Range(-ASTEROID_DIRECTION, ASTEROID_DIRECTION), Random.Range(-ASTEROID_DIRECTION, ASTEROID_DIRECTION));
    }

    public IEnumerator SpawnNewAsteroidRoutine() {
        if (GameManager.Instance.State != GameState.Start) {
            yield break;
        }

        var asteroidDirection = GetRandomAsteroidDirection();
        //spawn outside player area
        var playerPosition = FindObjectOfType<PlayerController>().transform.position;
        var randomX = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET);
        var randomY = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET); 
        var position = new Vector2(playerPosition.x + randomX, playerPosition.x + randomY);
        asteroidManagerSettings.CreateAsteroids(asteroidManagerSettings.DestroySteps, position, asteroidDirection);
        yield return new WaitForSeconds(asteroidManagerSettings.SpawnInterval);
        yield return SpawnNewAsteroidRoutine();
    }
}

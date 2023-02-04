using Player;
using Pool;
using Score;
using System.Collections;
using UnityEngine;
using Utils;

namespace Asteroid {
    public class AsteroidManager : MonoSingleton<AsteroidManager> {
        [SerializeField]
        private AsteroidSO asteroidManagerSettings;
        [SerializeField]
        private Transform firstAsteroidDirection;

        private const float ASTEROID_DIRECTION = 1f;
        private const float PLAYER_POSITIOM_OFFSET = 10f;
        private bool _isFirstAsteroid = true;

        public void DestroyAsteroid(AsteroidController asteroidController) {
            var destroySteps = asteroidController.DestroySteps;
            var position = asteroidController.transform.position;
            PoolManager.Pool(asteroidController.gameObject);
            destroySteps--;

            if (destroySteps == 0) {
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
            Vector2 position;
            var asteroidDirection = Vector2.zero;
            var playerPosition = FindObjectOfType<PlayerController>().transform.position;
            
            if (_isFirstAsteroid) {
                //spawn right of player
                position = new Vector2(playerPosition.x + PLAYER_POSITIOM_OFFSET, playerPosition.x);
                asteroidDirection = ((Vector2)firstAsteroidDirection.position - asteroidDirection).normalized;
                _isFirstAsteroid = false;
            }
            else {
                //spawn outside player area
                var randomX = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET);
                var randomY = Random.Range(-PLAYER_POSITIOM_OFFSET, PLAYER_POSITIOM_OFFSET);
                position = new Vector2(playerPosition.x + randomX, playerPosition.x + randomY);
                asteroidDirection = GetRandomAsteroidDirection();
            }
         
            asteroidManagerSettings.CreateAsteroids(asteroidManagerSettings.DestroySteps, position, asteroidDirection);
            yield return new WaitForSeconds(asteroidManagerSettings.SpawnInterval);
            yield return SpawnNewAsteroidRoutine();
        }
    }
}

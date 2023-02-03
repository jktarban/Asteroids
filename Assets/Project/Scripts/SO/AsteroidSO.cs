using Pool;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidManagerSettings", menuName = "GameSettings/AsteroidManagerSettings")]
public class AsteroidSO : ScriptableObject {
    [SerializeField]
    private GameObject asteroidPrefab;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    [Range(1, 5)]
    private int destroySteps;
    [SerializeField]
    private float speed;

    public int DestroySteps => destroySteps;
    public float SpawnInterval => spawnInterval;

    public void CreateAsteroids(int destroyStep, Vector2 position, Vector2 direction) {
        var asteroidObject = PoolManager.GetFromPool(asteroidPrefab.name + destroyStep);

        if (asteroidObject == null) {
            asteroidObject = Instantiate(asteroidPrefab).gameObject;
        }

        var asteroid = asteroidObject.GetComponent<AsteroidController>();
        asteroid.name = asteroidPrefab.name + destroyStep;
        asteroid.DestroySteps = destroyStep;
        asteroid.SetSpeed(speed, direction);
        asteroid.transform.localScale = asteroidPrefab.transform.localScale * destroyStep;
        asteroid.transform.position = position;
    }
}

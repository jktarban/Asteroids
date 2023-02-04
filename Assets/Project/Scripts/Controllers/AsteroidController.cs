using Pool;
using UnityEngine;

namespace Asteroid {
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidController : MonoBehaviour {

        private Rigidbody2D rigidbody2D;

        public int DestroySteps { get; set; }
        public void SetSpeed(float speed, Vector2 direction) {
            rigidbody2D.velocity = new Vector2(direction.x, direction.y) * speed;
        }

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Bullet")) {
                PoolManager.Pool(collision.gameObject);
                AsteroidManager.Instance.DestroyAsteroid(this);
            }
        }
    }
}

using Pool;
using System.Collections;
using UnityEngine;

namespace Bullet {
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletController : MonoBehaviour {
        [SerializeField]
        private BulletSO bulletSettings;

        private Rigidbody2D _rigidbody2D;

        public void Setup(Vector2 direction) {
            _rigidbody2D.velocity = direction * bulletSettings.Speed;
            StartCoroutine(DespawnRoutine());
        }

        private void Awake() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private IEnumerator DespawnRoutine() {
            yield return new WaitForSeconds(bulletSettings.DesPawnTime);
            PoolManager.Recycle(gameObject);
        }
    }
}

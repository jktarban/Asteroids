using UnityEngine;

namespace Bullet {
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "GameSettings/BulletSettings")]
    public class BulletSO : ScriptableObject {
        [SerializeField]
        private float speed = 20f;
        [SerializeField]
        private float despawnTime = 1f;

        public float Speed => speed;
        public float DespawnTime => despawnTime;
    }
}

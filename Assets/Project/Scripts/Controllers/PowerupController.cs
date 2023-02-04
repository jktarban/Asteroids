using TypeReferences;
using UnityEngine;

namespace Powerup {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PowerupController : MonoBehaviour {
        [SerializeField]
        [Inherits(typeof(IPowerup))]
        private TypeReference powerupType;

        private Rigidbody2D _rigidbody2D;

        public TypeReference PowerupType {
            get {
                return powerupType;
            }
            set {
                powerupType = value;
            }
        }

        internal string PowerupName => powerupType.Type.Name;

        internal void SetSpeed(float speed, Vector2 direction) {
            _rigidbody2D.velocity = new Vector2(direction.x, direction.y) * speed;
        }

        private void Awake() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}

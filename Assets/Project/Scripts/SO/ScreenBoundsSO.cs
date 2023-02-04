using UnityEngine;

namespace ScreenBounds {
    [CreateAssetMenu(fileName = "ScreenBoundsSettings", menuName = "GameSettings/ScreenBoundsSettings")]
    public class ScreenBoundsSO : ScriptableObject {
        [SerializeField]
        private float teleportOffset = 0.2f;
        [SerializeField]
        private float cornerOffset = 1f;

        public float TeleportOffset => teleportOffset;
        public float CornerOffset => cornerOffset;
    }
}

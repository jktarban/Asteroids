using UnityEngine;

namespace ScreenBounds {
    //reference https://www.youtube.com/watch?v=1a9ag16PeFw
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScreenBoundsController : MonoBehaviour {
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private ScreenBoundsSO screenBoundsSettings;

        private BoxCollider2D _boxCollider2D;

        private void Awake() {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start() {
            transform.position = Vector3.zero;
            UpdateBoundsSize();
        }
        private void OnTriggerExit2D(Collider2D collision) {
            var newPosition = CalaculateWrappedPosition(collision.transform.position);
            collision.transform.position = newPosition;
        }

        private void UpdateBoundsSize() {
            // half the size of the height of the screen
            var ySize = mainCamera.orthographicSize * 2;
            //width of the camera depends on the aspect ration and height
            var boxColliderSize = new Vector2(ySize * mainCamera.aspect, ySize);
            _boxCollider2D.size = boxColliderSize;
        }

        private Vector2 CalaculateWrappedPosition(Vector2 worldPosition) {
            var xBoundResult = Mathf.Abs(worldPosition.x) > Mathf.Abs(_boxCollider2D.bounds.min.x) - screenBoundsSettings.CornerOffset;
            var yBoundResult = Mathf.Abs(worldPosition.y) > Mathf.Abs(_boxCollider2D.bounds.min.y) - screenBoundsSettings.CornerOffset;

            var signWorldPosition = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

            if (xBoundResult && yBoundResult) {
                return Vector2.Scale(worldPosition, Vector2.one * -1) + Vector2.Scale(new Vector2(screenBoundsSettings.TeleportOffset, screenBoundsSettings.TeleportOffset), signWorldPosition);
            }
            else if (xBoundResult) {
                return new Vector2(worldPosition.x * -1, worldPosition.y) + new Vector2(screenBoundsSettings.TeleportOffset * signWorldPosition.x, screenBoundsSettings.TeleportOffset);
            }
            else if (yBoundResult) {
                return new Vector2(worldPosition.x, worldPosition.y * -1) + new Vector2(screenBoundsSettings.TeleportOffset, screenBoundsSettings.TeleportOffset * signWorldPosition.y);
            }
            else {
                return worldPosition;
            }
        }
    }
}

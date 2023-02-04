using UnityEngine;

public class CollideComponent : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asteroid")) {
            HealthManager.Instance.Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Powerup")) {
            PowerupManager.Instance.CheckPowerup(collision.GetComponent<PowerupController>());
        }
    }
}

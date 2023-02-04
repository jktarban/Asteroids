using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSOSettings", menuName = "GameSettings/PowerupSOSettings")]
public class PowerupSO : ScriptableObject {
    [SerializeField]
    private float spawnInterval;
}

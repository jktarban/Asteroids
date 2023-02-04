using UnityEngine;

[CreateAssetMenu(fileName = "PowerupManagerSettings", menuName = "GameSettings/PowerupManagerSettings")]
public class PowerupManagerSO : ScriptableObject {
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private PowerupSO[] powerups;
}

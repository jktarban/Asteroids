using Bullet;
using Pool;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSettings", menuName = "GameSettings/PowerupSettings")]
public class PowerupSO : ScriptableObject {
    [SerializeField]
    private float spawnInterval;
}

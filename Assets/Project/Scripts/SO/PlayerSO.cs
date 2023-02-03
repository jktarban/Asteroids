using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "GameSettings/PlayerSettings")]
public class PlayerSO : ScriptableObject
{
    [SerializeField]
    private float accelerationSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private int health;

    public float AccelerationSpeed => accelerationSpeed;
    public float RotationSpeed => rotationSpeed;
    public int Health => health;
}

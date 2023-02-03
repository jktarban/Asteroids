using UnityEngine;

[CreateAssetMenu(fileName = "SpeedSettings", menuName = "GameSettings/SpeedSettings")]
public class SpeedSO : ScriptableObject
{
    [SerializeField]
    private float speed;

    public float Speed => speed;
}

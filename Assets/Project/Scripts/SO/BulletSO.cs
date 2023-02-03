using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "GameSettings/BulletSettings")]
public class BulletSO : ScriptableObject
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float despawnTime;

    public float Speed => speed;
    public float DespawnTime => despawnTime;
}

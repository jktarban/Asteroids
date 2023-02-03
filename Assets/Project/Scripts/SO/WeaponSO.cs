using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "GameSettings/WeaponSettings")]
public class WeaponSO : ScriptableObject
{
    [SerializeField]
    private int timer;

    public int Timer => timer;
}

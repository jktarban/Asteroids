using Bullet;
using Pool;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "GameSettings/WeaponSettings")]
public class WeaponSO : ScriptableObject
{
    [SerializeField]
    private int timer;
    [SerializeField]
    private int bulletAmount;
    [SerializeField]
    private BulletController bulletPrefab;

    public int Timer => timer;

    public void CreateBullets(Transform direction) {
        var bullet = PoolManager.GetFromPool(bulletPrefab.gameObject);

        if(bullet == null) {
            bullet = Instantiate(bulletPrefab).gameObject;
        }

        bullet.transform.SetPositionAndRotation(direction.position, direction.rotation);
        bullet.name = bulletPrefab.name;
        bullet.GetComponent<BulletController>().Setup(direction.up);
    }
}

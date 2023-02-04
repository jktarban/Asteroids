using Bullet;
using Helpers;
using Pool;
using System.Collections;
using UnityEngine;

namespace Weapon {
    [CreateAssetMenu(fileName = "WeaponSettings", menuName = "GameSettings/WeaponSettings")]
    public class WeaponSO : ScriptableObject {
        [Header("-1 if no timer")]
        [SerializeField]
        private int timer;
        [SerializeField]
        private float fireInterval;
        [SerializeField]
        private int bulletAmount;
        [SerializeField]
        private float bulletDistance;
        [SerializeField]
        private BulletController bulletPrefab;

        private bool _canFire = true;

        public int Timer => timer;

        public void CreateBullets(Transform direction) {
            if (_canFire) {
                CoroutineHelper.Instance.StartCoroutine(CreateBulletsRoutine(direction));
            }
        }

        private IEnumerator CreateBulletsRoutine(Transform direction) {
            for (int i = 0; i < bulletAmount; i++) {
                var bullet = PoolManager.Recycle(bulletPrefab.name);

                if (bullet == null) {
                    bullet = Instantiate(bulletPrefab).gameObject;
                }

                bullet.transform.SetPositionAndRotation(direction.position, direction.rotation);
                bullet.name = bulletPrefab.name;
                bullet.GetComponent<BulletController>().Setup(direction.up);
                yield return new WaitForSeconds(bulletDistance);
            }

            CoroutineHelper.Instance.StartCoroutine(FireIntervalRoutine());
        }

        private IEnumerator FireIntervalRoutine() {
            _canFire = false;
            yield return new WaitForSeconds(fireInterval);
            _canFire = true;
        }

        private void OnEnable() {
            _canFire = true;
        }
    }
}

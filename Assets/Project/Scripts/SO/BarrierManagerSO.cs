using Pool;
using System.Linq;
using UnityEngine;

namespace Barrier {
    [CreateAssetMenu(fileName = "BarrierManagerSettings", menuName = "GameSettings/BarrierManagerSettings")]
    public class BarrierManagerSO : ScriptableObject {
        [SerializeField]
        private BarrierController[] barrierPrefabs;

        public BarrierController Createbarrier(string barrierName, Transform parent) {
            var barrierPrefab = barrierPrefabs.First(x => x.name == barrierName + "Prefab");

            var barrierObject = PoolManager.Recycle(barrierPrefab.name);

            if (barrierObject == null) {
                barrierObject = Instantiate(barrierPrefab).gameObject;
            }

            barrierObject.transform.SetParent(parent, false);
            barrierObject.name = barrierPrefab.name;

            return barrierObject.GetComponent<BarrierController>();
        }
    }
}

using Health;
using Pool;
using UnityEngine;

namespace Barrier {
    public class BarrierComponent : MonoBehaviour {
        [SerializeField]
        private Transform position;
        [SerializeField]
        private BarrierManagerSO barrierManagerSettings;
        private BarrierController _barrierController;

        public void SetBarrier(string barrierName) {
            if (_barrierController is object) {
                PoolManager.Pool(_barrierController.gameObject);
            }

            if (_barrierController != null) {
                _barrierController = null;
            }

            _barrierController = barrierManagerSettings.Createbarrier(barrierName, position);
            HealthManager.Instance.SetBarrier(_barrierController);
        }
    }
}

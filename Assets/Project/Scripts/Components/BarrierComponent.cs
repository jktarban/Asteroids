using Pool;
using System;
using UnityEngine;

public class BarrierComponent : MonoBehaviour {
    [SerializeField]
    private Transform position;
    [SerializeField]
    private BarrierManagerSO barrierManagerSettings;
    private BarrierController _barrierController;

    public void SetBarrier(Type type) {
        if (_barrierController is object) {
            PoolManager.Pool(_barrierController.gameObject);
        }

        if (_barrierController != null) {
            _barrierController = null;
        }

        _barrierController = barrierManagerSettings.Createbarrier(type.Name, position);
        HealthManager.Instance.SetBarrier(_barrierController);
    }
}

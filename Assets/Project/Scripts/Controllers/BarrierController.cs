using Pool;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    [SerializeField]
    private BarrierSO barrierSettings;
    private int _absorbAmount;

    private void OnEnable() {
        _absorbAmount = barrierSettings.AbsorbAmount;
    }

    public void UseBarrier() {
        _absorbAmount--;
        if (_absorbAmount == 0) {
            PoolManager.Recycle(gameObject);
        }
    }
}

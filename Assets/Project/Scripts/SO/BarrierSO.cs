using UnityEngine;

namespace Barrier {
    [CreateAssetMenu(fileName = "BarrierSettings", menuName = "GameSettings/BarrierSettings")]
    public class BarrierSO : ScriptableObject {
        [SerializeField]
        private int absorbAmount = 1;

        public int AbsorbAmount => absorbAmount;
    }
}

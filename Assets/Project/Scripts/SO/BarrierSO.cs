using UnityEngine;

namespace Barrier {
    [CreateAssetMenu(fileName = "BarrierSettings", menuName = "GameSettings/BarrierSettings")]
    public class BarrierSO : ScriptableObject {
        [SerializeField]
        private int absorbAmount;

        public int AbsorbAmount => absorbAmount;
    }
}

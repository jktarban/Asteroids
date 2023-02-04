using System;
using TypeReferences;
using UnityEngine;

namespace Barrier {
    [Serializable]
    public class BarrierSOItem {
        [SerializeField]
        [Inherits(typeof(IBarrier))]
        private TypeReference barrierType;
        [SerializeField]
        private BarrierSO barrierSettings;

        public TypeReference BarrierType => barrierType;
        public BarrierSO BarrierSettings => barrierSettings;
    }
}
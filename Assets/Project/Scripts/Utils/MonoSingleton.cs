using UnityEngine;

namespace Utils {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {

        public static T Instance { get { return instance; } }
        public static bool IsInitialized { get { return instance != null; } }

        private static T instance;

        private void Awake() {
            if (instance != null) {
                Destroy(instance.gameObject);
            }
            instance = this as T;
            instance.Init();
        }

        protected virtual void Init() { }
    }
}

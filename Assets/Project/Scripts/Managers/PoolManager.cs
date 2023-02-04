using System.Collections.Generic;
using UnityEngine;

namespace Pool {
    public static class PoolManager {
        private static List<GameObject> _poolObjects = new List<GameObject>();

        public static void Clear() {
            _poolObjects.Clear();
        }

        public static void Pool(GameObject gameObject) {
            gameObject.SetActive(false);
            _poolObjects.Add(gameObject);
        }

        public static GameObject Recycle(string name) {
            foreach (var poolObject in _poolObjects) {
                if (poolObject.name == name) {
                    if (!poolObject.activeInHierarchy) {
                        poolObject.SetActive(true);
                        return poolObject;
                    }
                }
            }

            return null;
        }
    }
}

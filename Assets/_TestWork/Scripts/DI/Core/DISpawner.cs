using UnityEngine;

namespace TestWork.DI.Core {
    public static class DISpawner {
        public static GameObject Instantiate(GameObject obj, Vector3 position, Quaternion rotation, Transform parent = null) {
            var result = Object.Instantiate(obj, position, rotation, parent);
            DIContainer.ResolveChildren(result);
        
            return result;
        }
    
    }
}

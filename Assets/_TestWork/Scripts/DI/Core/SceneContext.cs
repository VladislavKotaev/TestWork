using UnityEngine;

namespace TestWork.DI.Core {
    [DefaultExecutionOrder(-100)]
    public class SceneContext : DIContext {
        private void Awake() {
            DIContainer.AddSceneContext(this);
        }

        private void OnDestroy() {
            DIContainer.RemoveSceneContext(this);
        }
    
    }
}

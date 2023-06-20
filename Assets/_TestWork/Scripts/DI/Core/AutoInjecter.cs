using UnityEngine;

namespace TestWork.DI.Core {
    [DefaultExecutionOrder(-50)]
    public class AutoInjecter : MonoBehaviour {
        private void Awake() {
            DIContainer.ResolveChildren(gameObject);
        }
    }
}

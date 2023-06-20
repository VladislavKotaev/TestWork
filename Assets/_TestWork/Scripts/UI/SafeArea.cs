using TestWork.DI.Core;
using UnityEngine;

namespace TestWork.UI {
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour, IInjectable {
        private SafeAreaWatcher _safeAreaWatcher;
        private RectTransform _rectTransform;
    
        public void Construct(SafeAreaWatcher safeAreaWatcher) {
            _safeAreaWatcher = safeAreaWatcher;
            _safeAreaWatcher.OnSafeAreaChanged += OnSafeAreaChanged;
            _rectTransform = GetComponent<RectTransform>();
            OnSafeAreaChanged(_safeAreaWatcher.MinAnchor, _safeAreaWatcher.MaxAnchor);
        }

        private void OnSafeAreaChanged(Vector2 minAnchor, Vector2 maxAnchor) {
            _rectTransform.anchorMin = minAnchor;
            _rectTransform.anchorMax = maxAnchor;
        }

        private void OnDestroy() {
            if (_safeAreaWatcher != null && _safeAreaWatcher.transform != null) {
                _safeAreaWatcher.OnSafeAreaChanged -= OnSafeAreaChanged;
            }
        }
    
    }
}

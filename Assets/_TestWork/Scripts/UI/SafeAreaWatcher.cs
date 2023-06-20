using System;
using UnityEngine;

namespace TestWork.UI {
    public class SafeAreaWatcher : MonoBehaviour {
        public Action<Vector2, Vector2> OnSafeAreaChanged { get; set; }
        public Vector2 MinAnchor { get; private set; }
        public Vector2 MaxAnchor { get; private set; }
 
        private ScreenOrientation _lastOrientation = ScreenOrientation.Portrait;
        private Vector2Int _lastResolution = Vector2Int.zero;
        private Rect _lastSafeArea;
 

        private void Awake() {
            _lastOrientation = Screen.orientation;
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
            _lastSafeArea = Screen.safeArea;
            ApplySafeArea();
        }

        private void Update() {
            if (Screen.orientation != _lastOrientation) {
                OrientationChanged();
            }

            if (Screen.safeArea != _lastSafeArea) {
                SafeAreaChanged();
            }

            if (Screen.width != _lastResolution.x || Screen.height != _lastResolution.y) {
                ResolutionChanged();
            }
        }
 
        private void ApplySafeArea() {
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
 
            MinAnchor = new Vector2(anchorMin.x / Screen.width, anchorMin.y / Screen.height);
            MaxAnchor = new Vector2(anchorMax.x / Screen.width, anchorMax.y / Screen.height);
            OnSafeAreaChanged?.Invoke(MinAnchor, MaxAnchor);
        }
    
        private void OrientationChanged() {
            _lastOrientation = Screen.orientation;
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
            ApplySafeArea();
        }
 
        private void ResolutionChanged() {
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
            ApplySafeArea();
        }
 
        private void SafeAreaChanged() {
            _lastSafeArea = Screen.safeArea;
            ApplySafeArea();
        }
    
    }
}
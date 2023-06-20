using TestWork.DI.Core;
using TestWork.Saving;
using UnityEngine;

namespace TestWork.Loading {
    public class MainSceneLoader : MonoBehaviour, IInjectable {
        [SerializeField] private bool _ignoreAutoLoading;
        private SceneLoader _sceneLoader;
    
        public void Construct(SaveData saveData, SceneLoader sceneLoader) {
            _sceneLoader = sceneLoader;
#if UNITY_EDITOR
            if (_ignoreAutoLoading) {
                return;
            }        
#endif
            Debug.Log(saveData.IsInitialized);
            if (saveData.IsInitialized) {
                LoadMainScene();
                return;
            }
        }

        public void LoadMainScene() {
            _sceneLoader.LoadMainScene();
        }
    
    }
}
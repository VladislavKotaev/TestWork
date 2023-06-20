using TestWork.DI.Core;
using TestWork.Loading;

namespace TestWork.Saving {
    public class StartReturner {
        private SaveClearer _saveClearer;
        private SceneLoader _sceneLoader;
    
        public StartReturner() {
            _saveClearer = new SaveClearer();
            _sceneLoader = DIContainer.GetResolvedValue<SceneLoader>();
        }
    
        public void ReturnAndClear() {
            _saveClearer.ClearSave();
            _sceneLoader.LoadStartingScene();
        }
    
    }
}

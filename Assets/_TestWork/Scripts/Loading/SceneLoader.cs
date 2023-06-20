using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestWork.Loading {
    [CreateAssetMenu(menuName = "ScriptableObject/SceneLoader", order = 133)]
    public class SceneLoader : ScriptableObject {
        [SerializeField] private string _mainSceneName;
        [SerializeField] private string _startingSceneName;

        public void LoadMainScene() {
            SceneManager.LoadScene(_mainSceneName);
        
        }

        public void LoadStartingScene() {
            SceneManager.LoadScene(_startingSceneName);
        }
    
    }
}

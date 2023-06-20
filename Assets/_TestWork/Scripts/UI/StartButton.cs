using TestWork.DI.Core;
using TestWork.Loading;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    [RequireComponent(typeof(Button))]
    public class StartButton : MonoBehaviour, IInjectable {
        public void Construct(MainSceneLoader mainSceneLoader) {
            GetComponent<Button>().onClick.AddListener(mainSceneLoader.LoadMainScene);
        }
    
    }
}

using TestWork.DI.Core;
using TestWork.UI;
using UnityEngine;

namespace TestWork.Buildings.Clickables {
    public class ClickableWindowOpener : MonoBehaviour, IInjectable {
        [SerializeField] private WindowType _windowType;
    
        private WindowsController _windowsController;
    
        public void Construct(WindowsController windowsController) {
            _windowsController = windowsController;
            GetComponent<ObjectClickEvents>().OnClick += () => OpenWindow();
        }

        protected virtual IWindow OpenWindow() {
            return _windowsController.OpenWindow(_windowType);
        }
    
    }
}

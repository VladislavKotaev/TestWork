using TestWork.DI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    public class CloseButton : MonoBehaviour, IInjectable {
        private WindowsController _windowsController;
        private IWindow _attachedWindow;
    
        public void Construct(WindowsController windowsController) {
            _windowsController = windowsController;
            _attachedWindow = GetComponentInParent<IWindow>(true);
            GetComponent<Button>().onClick.AddListener(Close);
        }

        private void Close() {
            // Закрываем окно через контроллер окон, а не напрямую, чтобы иметь возможность потом подвязать дополнительный функционал
            _windowsController.CloseWindow(_attachedWindow);
        }
    
    }
}

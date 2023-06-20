using TestWork.DI.Core;
using UnityEngine;

namespace TestWork.UI {
    public class FinalGameWindow : MonoBehaviour, IWindow, IInjectable {
        public WindowType Type => WindowType.Final;

        public void Construct(WindowsController windowsController) {
            windowsController.AddWindow(this);
        }
        
        public void Open() {
            gameObject.SetActive(true);
        }

        public void Close() {
            gameObject.SetActive(false);
        }
        
    }
}

using System.Collections.Generic;

namespace TestWork.UI {
    public class WindowsController {
        public List<IWindow> Windows => _windows;
    
        private List<IWindow> _windows = new List<IWindow>();

        public void AddWindow(IWindow window) {
            _windows.Add(window);
        }
    
        public void OpenWindow(IWindow iWindow) {
            foreach (var window in _windows) {
                if (window == iWindow) {
                    window.Open();
                } else {
                    window.Close();
                }
            }
        }

        public IWindow OpenWindow(WindowType windowType) {
            IWindow result = null;
            foreach (var window in _windows) {
                if (window.Type == windowType) {
                    window.Open();
                    result = window;
                } else {
                    window.Close();
                }
            }

            return result;
        }

        public void CloseWindow(IWindow window) {
            window.Close();
        }
    
    }
}
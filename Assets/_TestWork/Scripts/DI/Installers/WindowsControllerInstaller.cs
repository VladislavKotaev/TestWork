using System;
using System.Collections.Generic;
using TestWork.UI;

namespace TestWork.DI.Installers {
    public class WindowsControllerInstaller {
        public WindowsControllerInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(WindowsController), new WindowsController());
        }
    }
}

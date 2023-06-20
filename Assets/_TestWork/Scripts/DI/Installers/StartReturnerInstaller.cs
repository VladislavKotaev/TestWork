using System;
using System.Collections.Generic;
using TestWork.Saving;

namespace TestWork.DI.Installers {
    public class StartReturnerInstaller {
        public StartReturnerInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(StartReturner), new StartReturner());
        }
    }
}

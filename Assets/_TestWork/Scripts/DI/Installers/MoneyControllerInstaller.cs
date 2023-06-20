using System;
using System.Collections.Generic;
using TestWork.GameStateControllers;

namespace TestWork.DI.Installers {
    public class MoneyControllerInstaller {
        public MoneyControllerInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(MoneyController), new MoneyController());
        }
    }
}

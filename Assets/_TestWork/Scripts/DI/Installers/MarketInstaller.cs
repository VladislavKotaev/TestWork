using System;
using System.Collections.Generic;
using TestWork.Buildings;

namespace TestWork.DI.Installers {
    public class MarketInstaller {
        public MarketInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(Market), new Market());
        }
    }
}

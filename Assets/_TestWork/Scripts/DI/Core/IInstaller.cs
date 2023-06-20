using System;
using System.Collections.Generic;

namespace TestWork.DI.Core {
    public interface IInstaller {
        public void InstallBindings(Dictionary<Type, object> objects);
    }
}

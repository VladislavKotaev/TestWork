using System;
using System.Collections.Generic;
using TestWork.Inventory;

namespace TestWork.DI.Installers {
    public class GlobalStorageInstaller {
        public GlobalStorageInstaller(Dictionary<Type, object> bindings) {
            var globalStorage = new AllItemsInventory();
            bindings.Add(typeof(IInventory), globalStorage);
            bindings.Add(typeof(AllItemsInventory), globalStorage);
        }
    }
}

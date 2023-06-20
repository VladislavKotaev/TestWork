using System;
using System.Collections.Generic;
using TestWork.Saving;

namespace TestWork.DI.Installers {
    public class SaveDataInstaller {
        public SaveDataInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(SaveData), SaveDataLoader.LoadSaveData());
        }
    }
}

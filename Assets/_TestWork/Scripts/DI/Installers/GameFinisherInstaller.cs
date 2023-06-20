using System;
using System.Collections.Generic;
using TestWork.GameStateControllers;

namespace TestWork.DI.Installers {
    public class GameFinisherInstaller {
        public GameFinisherInstaller(Dictionary<Type, object> bindings) {
            bindings.Add(typeof(GameFinisher), new GameFinisher());
        }
    }
}

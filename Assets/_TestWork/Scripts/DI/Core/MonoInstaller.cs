using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestWork.DI.Core {
    public class MonoInstaller : MonoBehaviour, IInstaller {
        [SerializeField] protected Object[] _bindings;
    
        public void InstallBindings(Dictionary<Type, object> objects) {
            foreach (var binding in _bindings) {
                objects.Add(binding.GetType(), binding);
            }
        }
    
    }
}

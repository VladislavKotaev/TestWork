using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestWork.DI.Core {
    public abstract class DIContext : MonoBehaviour {
        [SerializeField] private MonoInstaller[] _monoInstallers = Array.Empty<MonoInstaller>();
        [SerializeField] private string[] _installerTypes = Array.Empty<string>();

        private const string _installersNamePrefix = "TestWork.DI.Installers.";
        private Dictionary<Type, object> _bindings = new Dictionary<Type, object>();

        public void Init() {
            foreach (var monoInstaller in _monoInstallers) {
                monoInstaller.InstallBindings(_bindings);
            }

            foreach (var installerName in _installerTypes) {
                Type.GetType(_installersNamePrefix+installerName).GetConstructor(
                    new Type[]{typeof(Dictionary<Type, object>)})?.Invoke(new object[]{ _bindings });
            }
        }

        public bool Resolve(ref object obj) {
            return _bindings.TryGetValue(obj.GetType(), out obj);
        }
    
        public bool Resolve(ref object obj, Type type) {
            return _bindings.TryGetValue(type, out obj);
        }

    }
}
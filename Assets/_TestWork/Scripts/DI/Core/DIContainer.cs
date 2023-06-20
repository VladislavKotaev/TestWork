using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TestWork.DI.Core {
    public static class DIContainer {
        private const string _projectContextPath = "ProjectContext";
        private static List<DIContext> _contexts = new List<DIContext>();
        private const string _injectMethodName = "Construct";

        static DIContainer() {
            var projectContext = UnityEngine.Object.Instantiate(Resources.Load<ProjectContext>(_projectContextPath));
        
            _contexts.Add(projectContext);
            projectContext.Init();
        }
    
        public static void AddSceneContext(SceneContext sceneContext) {
            _contexts.Add(sceneContext);
            sceneContext.Init();
            var rootObjects = sceneContext.gameObject.scene.GetRootGameObjects();
            foreach (var rootObject in rootObjects) {
                ResolveChildren(rootObject);
            }
        }

        public static void ResolveChildren(GameObject rootObject) {
            var injectables = rootObject.GetComponentsInChildren<IInjectable>(true);
            foreach (var injectable in injectables) {
                var method = injectable.GetType().GetMethod(_injectMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (method == null) {
                    continue;
                }
                var parameterInfos = method.GetParameters();
                var parameters = new object[parameterInfos.Length];
                for (int i = 0; i < parameterInfos.Length; i++) {
                    Resolve(ref parameters[i], parameterInfos[i].ParameterType);
                }
                method.Invoke(injectable, parameters);
            }
        }

        public static void RemoveSceneContext(SceneContext sceneContext) {
            _contexts.Remove(sceneContext);
        }

        public static void Resolve(ref object obj, Type type) {
            for (int i = 0; i < _contexts.Count; i++) {
                if (_contexts[i].Resolve(ref obj, type)) {
                    return;
                }
            }
            Debug.LogWarning("Value can't be resolved");
        }
    
        public static void Resolve(ref object obj) {
            Resolve(ref obj, obj.GetType());
        }

        public static T GetResolvedValue<T>() {
            object result = null;
            Resolve(ref result, typeof(T));
            return (T)result;
        }

    }
}
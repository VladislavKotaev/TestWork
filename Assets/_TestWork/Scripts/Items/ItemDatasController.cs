using System.Collections.Generic;
using TestWork.Attributes;
using UnityEngine;

namespace TestWork.Items {
    [CreateAssetMenu(menuName = "ScriptableObject/ResourceDatasController", order = 131)]
    public class ItemDatasController : ScriptableObject {
        [ShowOnly,SerializeField] private ItemData[] _resourceDatas;
    
        public ItemData[] ResourceDatas => _resourceDatas;
        private Dictionary<string, ItemData> _resourceDatasDictionary;
        private bool _isResourceDatasDictionaryInited;
    
    
        public ItemData GetResourceDataByName(string resourceName) {
            if (!_isResourceDatasDictionaryInited) {
                InitResourceDatasDictionary();
            }

            return _resourceDatasDictionary[resourceName];
        }
    
        public int GetResourceIdByName(string resourceName) {
            if (!_isResourceDatasDictionaryInited) {
                InitResourceDatasDictionary();
            }

            return _resourceDatasDictionary[resourceName].Id;
        }

        private void InitResourceDatasDictionary() {
            _resourceDatasDictionary = new Dictionary<string, ItemData>();
            for (int i = 0; i < _resourceDatas.Length; i++) {
                _resourceDatasDictionary.Add(_resourceDatas[i].name, _resourceDatas[i]);
            }
        }
    
#if UNITY_EDITOR
        [SerializeField] private string _path = "Assets/_TestWork/ScriptableObjects/ResourceDatas/Datas";
    
        public void FindResourceDatas() {
            var assetGuids = UnityEditor.AssetDatabase.FindAssets("t:ResourceData", new []{ _path });
            _resourceDatas = new ItemData[assetGuids.Length];
            for (int i = 0; i < _resourceDatas.Length; i++) {
                _resourceDatas[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<ItemData>(UnityEditor.AssetDatabase.GUIDToAssetPath(assetGuids[i]));
                _resourceDatas[i].Id = i;
                UnityEditor.EditorUtility.SetDirty(_resourceDatas[i]);
            }
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif

    }
}
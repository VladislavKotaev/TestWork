using UnityEngine;

namespace TestWork.Items {
    [System.Serializable]
    public struct ResourceNameCountPair {
        [SerializeField] private string _name;
        [SerializeField] private int _count;

        public string Name => _name;
        public int Count => _count;

        public ResourceNameCountPair(string name, int count) {
            _name = name;
            _count = count;
        }
    }
}

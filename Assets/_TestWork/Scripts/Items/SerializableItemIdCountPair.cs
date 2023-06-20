using UnityEngine;

namespace TestWork.Items {
    [System.Serializable]
    public struct SerializableItemIdCountPair {
        [SerializeField] private int _resourceId;
        [SerializeField] private int _count;
    
        public int ResourceId => _resourceId;
        public int Count => _count;
    
        public SerializableItemIdCountPair(int id, int count) {
            _resourceId = id;
            _count = count;
        }
    }
}

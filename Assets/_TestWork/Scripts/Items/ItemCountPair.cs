using UnityEngine;
using UnityEngine.Serialization;

namespace TestWork.Items {
    [System.Serializable]
    public class ItemCountPair {
        [FormerlySerializedAs("_resource")] [SerializeField] private ItemData _item;
        [SerializeField] private int _count;
    
        public ItemData Item => _item;
        public int Count {
            get => _count;
            set => _count = value;
        }
    }
}
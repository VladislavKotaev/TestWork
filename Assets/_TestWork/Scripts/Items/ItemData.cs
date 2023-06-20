using TestWork.Attributes;
using UnityEngine;

namespace TestWork.Items {
    [CreateAssetMenu(menuName = "ScriptableObject/ItemData", order = 130)]
    public class ItemData : ScriptableObject {
        [SerializeField] private int _sellingCost;
        [SerializeField, ShowOnly] public int _id;
        [SerializeField] private Sprite _icon;
    
        public int Id {
            get => _id;
            set => _id = value;
        }
        public int SellingCost => _sellingCost;
        public Sprite Icon => _icon;
    }
}
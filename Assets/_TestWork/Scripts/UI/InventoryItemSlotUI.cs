using TestWork.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    public class InventoryItemSlotUI : MonoBehaviour {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _itemNameText;
        [SerializeField] private TextMeshProUGUI _itemCountText;
    
        private const string _emptySlotText = "Empty";
    
        public void ShowItem(ItemData itemData, int count) {
            gameObject.SetActive(true);
            if (itemData == null) {
                _icon.gameObject.SetActive(false);
                _itemNameText.text = _emptySlotText;
                _itemCountText.text = "";
            } else {
                _icon.sprite = itemData.Icon;
                _icon.gameObject.SetActive(true);
                _itemNameText.text = itemData.name;
                _itemCountText.text = count.ToString();
            }    
        }

        public void Disable() {
            gameObject.SetActive(false);
        }
    
    }
}

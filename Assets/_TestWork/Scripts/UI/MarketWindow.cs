using TestWork.Buildings;
using TestWork.DI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    public class MarketWindow :  MonoBehaviour, IWindow, IInjectable {
        [SerializeField] private Button _nextItemButton;
        [SerializeField] private Button _sellingItemButton;
        [SerializeField] private TextMeshProUGUI _changingValuesText;
    
        public WindowType Type => WindowType.Market;
    
        private Market _market;
        private Image _sellingItemImage;
    
        public void Construct(WindowsController windowsController, Market market) {
            windowsController.AddWindow(this);
            _market = market;
            _market.OnUpdate += ShowItem;
            _nextItemButton.onClick.AddListener(market.OnNextItem);
            _sellingItemButton.onClick.AddListener(market.OnSellButton);
            _sellingItemImage = _nextItemButton.image;
        }

        private void ShowItem() {
            if (_market.ActiveItem == null) {
                _sellingItemImage.sprite = null;
                _changingValuesText.text = "0\n\n0\n\n0";
                _sellingItemButton.interactable = false;
            } else {
                _sellingItemImage.sprite = _market.ActiveItem.Icon;
                _changingValuesText.text = $"{_market.ActiveItem.SellingCost}\n\n{_market.ActiveItemCount}\n\n{_market.ActiveItem.SellingCost * _market.ActiveItemCount}";
                _sellingItemButton.interactable = true;
            }
        }

        public void Open() {
            gameObject.SetActive(true);
            _market.IsActive = true;
        }

        public void Close() {
            gameObject.SetActive(false);
            _market.IsActive = false;
        }

        private void OnNextItemButton() {
            _market.OnNextItem();
        }

    }
}
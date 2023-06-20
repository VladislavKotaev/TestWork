using System;
using TestWork.DI.Core;
using TestWork.GameStateControllers;
using TestWork.Inventory;
using TestWork.Items;

namespace TestWork.Buildings {
    public class Market {
        public Action OnUpdate { get; set; }
        public ItemData ActiveItem { get; private set; }
        public int ActiveItemCount { get; private set; }
        public bool IsActive {
            get => _isActive;
            set {
                if (value == _isActive) return;
            
                if (value) {
                    UpdateMarket();
                    _inventory.OnItemsChanged += UpdateMarket;
                } else {
                    _inventory.OnItemsChanged -= UpdateMarket;
                }

                _isActive = value;
            }
        }
    
        private readonly MoneyController _moneyController;
        private readonly IInventory _inventory;
        private readonly ItemDatasController _itemDatasController;
        private bool _isActive;
        private SerializableItemIdCountPair[] _resourceIdCountPairs;
        private int _lastItemInPair = -1;

        public Market() {
            _inventory = DIContainer.GetResolvedValue<IInventory>();
            _itemDatasController = DIContainer.GetResolvedValue<ItemDatasController>();
            _moneyController = DIContainer.GetResolvedValue<MoneyController>();
        }
    
        public void OnNextItem() {
            if (_resourceIdCountPairs.Length > 0) {
                _lastItemInPair = _resourceIdCountPairs.Length > _lastItemInPair + 1 ? _lastItemInPair + 1 : 0;
                ActiveItem = _itemDatasController.ResourceDatas[_resourceIdCountPairs[_lastItemInPair].ResourceId];
                ActiveItemCount = _resourceIdCountPairs[_lastItemInPair].Count;
                OnUpdate?.Invoke();
            }
        }

        public void OnSellButton() {
            if (ActiveItem == null) {
                return;
            }

            _moneyController.Money += ActiveItem.SellingCost * ActiveItemCount;
            _inventory.Remove(ActiveItem.Id, ActiveItemCount);
        }

        /// <summary>
        /// Для оптимизации можно было бы убрать часть кода, но тогда игрокам придётся чаще листать список сначала, а это плохо
        /// </summary>
        private void UpdateMarket() {
            _resourceIdCountPairs = _inventory.GetAllItems();
            if (_resourceIdCountPairs.Length == 0) {
                ActiveItem = null;
                ActiveItemCount = 0;
                _lastItemInPair = -1;
                OnUpdate?.Invoke();
                return;
            }

            if (_lastItemInPair >= 0) {
                if (_resourceIdCountPairs.Length > _lastItemInPair
                    && _resourceIdCountPairs[_lastItemInPair].ResourceId == ActiveItem.Id) {
                    ActiveItemCount = _resourceIdCountPairs[_lastItemInPair].Count;
                    OnUpdate?.Invoke();
                    return;
                }

                for (int i = 0; i < _resourceIdCountPairs.Length; i++) {
                    if (_resourceIdCountPairs[i].ResourceId == ActiveItem.Id) {
                        _lastItemInPair = i;
                        ActiveItemCount = _resourceIdCountPairs[i].Count;
                        OnUpdate?.Invoke();
                        return;
                    }
                }
            }

            _lastItemInPair = 0;
            ActiveItem = _itemDatasController.ResourceDatas[_resourceIdCountPairs[0].ResourceId];
            ActiveItemCount = _resourceIdCountPairs[0].Count;
            OnUpdate?.Invoke();
        }
    
    }
}

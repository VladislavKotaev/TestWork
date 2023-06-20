using System.Collections.Generic;
using TestWork.DI.Core;
using TestWork.Inventory;
using TestWork.Items;
using UnityEngine;

namespace TestWork.UI {
    public class InventoryWindow : MonoBehaviour, IWindow, IInjectable {
        [SerializeField] private Transform _itemSlotsParent;
    
        public WindowType Type => WindowType.Inventory;
    
        private IInventory _inventory;
        private InventoryItemSlotUI _inventoryItemSlotUI;
        private List<InventoryItemSlotUI> _inventoryItemSlotUis;
        private ItemDatasController _itemDatasController;
    
        public void Construct(IInventory inventory, InventoryItemSlotUI inventoryItemSlotUI, ItemDatasController itemDatasController, WindowsController windowsController) {
            _inventory = inventory;
            _inventoryItemSlotUI = inventoryItemSlotUI;
            _inventoryItemSlotUis = new List<InventoryItemSlotUI>();
            _itemDatasController = itemDatasController;
            _inventoryItemSlotUis.Add(Instantiate(_inventoryItemSlotUI, _itemSlotsParent));
            windowsController.AddWindow(this);
        }

        public void Open() {
            gameObject.SetActive(true);
            _inventory.OnItemsChanged += ShowItems;
            ShowItems();
        }
    
        public void Close() {
            gameObject.SetActive(false);
            _inventory.OnItemsChanged -= ShowItems;
        }

        private void ShowItems() {
            var items = _inventory.GetAllItems();
            if (_inventoryItemSlotUis.Count < items.Length) {
                for (int i = _inventoryItemSlotUis.Count; i < items.Length; i++) {
                    _inventoryItemSlotUis.Add(Instantiate(_inventoryItemSlotUI, _itemSlotsParent));
                }
            }

            int itemSlotId = 0;
            if (items.Length == 0) {
                _inventoryItemSlotUis[itemSlotId++].ShowItem(null, 0);
            }

            while (itemSlotId < items.Length) {
                _inventoryItemSlotUis[itemSlotId].ShowItem(_itemDatasController.ResourceDatas[items[itemSlotId].ResourceId], items[itemSlotId].Count);
                itemSlotId++;
            }

            while (itemSlotId < _inventoryItemSlotUis.Count) {
                _inventoryItemSlotUis[itemSlotId++].Disable();
            }
        }

    }
}
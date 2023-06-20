using System.Collections;
using TestWork.DI.Core;
using TestWork.GameStateControllers;
using TestWork.Inventory;
using TestWork.Items;
using UnityEngine;

namespace TestWork.Saving {
    public class SavesController : MonoBehaviour, IInjectable {
        [SerializeField] private float _savingDelay = 20f;
    
        private MoneyController _moneyController;
        private IInventory _globalStorage;
        private SaveData _saveData;
        private ItemDatasController _itemDatasController;
    
        public void Construct(MoneyController moneyController, IInventory globalStorage, ItemDatasController itemDatasController, SaveData saveData) {
            _itemDatasController = itemDatasController;
            _moneyController = moneyController;
            _globalStorage = globalStorage;
            _saveData = saveData;
        
            if (_saveData.IsInitialized) {
                _moneyController.Money = _saveData.MoneyCount;
                foreach (var nameCountPair in _saveData.NameCountPairs) {
                    _globalStorage.Add(_itemDatasController.GetResourceIdByName(nameCountPair.Name), nameCountPair.Count);
                }
            }
            StartCoroutine(SavingRoutine());
        }

        private void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus) {
                Save();
            }
        }

        private void OnApplicationFocus(bool hasFocus) {
            if (!hasFocus) {
                Save();
            }
        }

        private void OnApplicationQuit() {
            Save();
        }

        private void Save() {
            _saveData.IsInitialized = true;
            var allItemsFromInventory = _globalStorage.GetAllItems();
            _saveData.NameCountPairs = new ResourceNameCountPair[allItemsFromInventory.Length];
            for (int i = 0; i < allItemsFromInventory.Length; i++) {
                _saveData.NameCountPairs[i] = 
                    new ResourceNameCountPair(_itemDatasController.ResourceDatas[allItemsFromInventory[i].ResourceId].name, allItemsFromInventory[i].Count);
            }
            _saveData.MoneyCount = _moneyController.Money;
            SaveDataWriter.WriteSaveData(_saveData);
        }

        private IEnumerator SavingRoutine() {
            while (true) {
                yield return new WaitForSeconds(_savingDelay);
                Save();
            }
        }
    
    }
}
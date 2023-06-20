using System;
using System.Collections.Generic;
using TestWork.DI.Core;
using TestWork.Items;

namespace TestWork.Inventory {
    public class AllItemsInventory : IInventory {
        // Пока не нужно
        // public int[] Items => _items;
        public Action OnItemsChanged { get; set; }

        private SerializableItemIdCountPair[] _cashedIdCountPairs;
        private int[] _items;
    
        public AllItemsInventory() {
            var datasController = DIContainer.GetResolvedValue<ItemDatasController>();
            _items = new int[datasController.ResourceDatas.Length];
            OnItemsChanged += () => _cashedIdCountPairs = null;
        }

        public bool HasItem(int id, int count) {
            return _items[id] >= count;
        }

        public bool CanAdd(int id, int count) => true;

        public void Remove(int id, int count) {
            _items[id] = _items[id] >= count ? _items[id] - count : 0;
            OnItemsChanged?.Invoke();
        }

        public void Add(int id, int count) {
            _items[id] += count;
            OnItemsChanged?.Invoke();
        } 

        /// <summary>
        /// Почему я не сделал тут возврат _items? Предполагается, что AllItemsInventory - это одна из множества реализаций IInventory.
        /// И это единственная, где можно сделать массив, вмещающий все предметы в игре, а значит единственный вариант, где нам достаточно массива int.
        /// Можно было сделать, чтобы все взаимодействия с инвентарём использовали именно такую реализацию, что положительно скажется на производительности,
        /// но отрицательно - на расширяемости. Ещё можно оптимизировать это всё. Но я считаю, что в рамках текущей задачи, это достаточное решение.
        /// </summary>
        public SerializableItemIdCountPair[] GetAllItems() {
            if (_cashedIdCountPairs != null) {
                return _cashedIdCountPairs;
            }
            var items = new List<SerializableItemIdCountPair>();
            for (int i = 0; i < _items.Length; i++) {
                if (_items[i] > 0) {
                    items.Add(new SerializableItemIdCountPair(i, _items[i]));
                }
            }
            _cashedIdCountPairs = items.ToArray();
            return _cashedIdCountPairs;
        }
    
    }
}


using System;
using TestWork.Items;

namespace TestWork.Inventory {
    public interface IInventory {
        bool HasItem(int id, int count);
        bool CanAdd(int id, int count);
        void Remove(int id, int count);
        void Add(int id, int count);
        Action OnItemsChanged { get; set; }
        SerializableItemIdCountPair[] GetAllItems();

    }
}
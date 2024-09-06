using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedSlot : IInventorySlot
{
    public ItemId Id { get => _id; }
    public int ItemsCount { get => _itemsCount; }
    public int FreeSpace { get => System.Int32.MaxValue; }
    public bool IsEmpty { get => _itemsCount < 1; }

    private ItemId _id;
    private int _itemsCount = 0;

    public bool AddItems(ItemId id, int amount)
    {
        if (IsEmpty)
            _id = id;

        if (_id != id)
            return false;

        _itemsCount += amount > 0 ? amount : 0;
        return true;
    }

    public int RemoveItems(int amount)
    {
        int toRemove = Mathf.Min(amount, _itemsCount);
        if (toRemove < 1)
            return 0;

        _itemsCount -= toRemove;
        return toRemove;
    }
}

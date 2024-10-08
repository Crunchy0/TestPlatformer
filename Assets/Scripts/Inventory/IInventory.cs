using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    public bool FixedSlotsCount { get; }
    public int SlotsCount { get; }
    public InventorySaveData SaveData { get; }

    public bool TryAddItems(ItemId id, int amount, out int index);
    public int TryRemoveItems(ItemId id, int amount);
    public int TryRemoveItems(int index, int amount);
    public bool GetSlot(int index, out IInventorySlot slot);
    public bool GetSlot(ItemId id, out IInventorySlot slot);
    public bool Has(ItemId id);
}

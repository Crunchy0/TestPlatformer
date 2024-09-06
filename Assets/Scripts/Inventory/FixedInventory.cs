using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedInventory : IInventory
{
    public bool FixedSlotsCount => true;
    public int SlotsCount { get => _slots.Count; }

    private List<IInventorySlot> _slots = new();
    private int _firstFreeSlotIdx = 0;

    public FixedInventory(int slotsCount)
    {
        for(int i = 0; i < slotsCount; i++)
            _slots.Add(new UnlimitedSlot());
    }

    public bool TryAddItems(ItemId id, int amount, out int index)
    {
        if(!FindIndexById(id, out index))
            index = _firstFreeSlotIdx;

        if(_slots[index].AddItems(id, amount))
        {
            PushFirstFreeSlot();
            return true;
        }
        return false;
    }

    public int TryRemoveItems(ItemId id, int amount)
    {
        if (!FindIndexById(id, out int idx))
            return 0;
        return TryRemoveItems(idx, amount);
    }

    public int TryRemoveItems(int index, int amount)
    {
        if (index < 0 || index >= _slots.Count)
            return 0;

        int removed = _slots[index].RemoveItems(amount);

        if (_slots[index].IsEmpty && index < _firstFreeSlotIdx)
            _firstFreeSlotIdx = index;

        return removed;
    }

    public bool GetSlot(int index, out IInventorySlot slot)
    {
        slot = null;
        if (index < 0 || index >= _slots.Count)
            return false;

        slot = _slots[index];
        return true;
    }

    public bool GetSlot(ItemId id, out IInventorySlot slot)
    {
        slot = null;
        return FindIndexById(id, out int idx) && GetSlot(idx, out slot);
    }

    public bool Has(ItemId id)
    {
        bool idPresent = FindIndexById(id, out var idx);
        if (idPresent && !_slots[idx].IsEmpty)
            return true;
        return false;
    }

    private void PushFirstFreeSlot()
    {
        while (_firstFreeSlotIdx < _slots.Count)
        {
            if (_slots[_firstFreeSlotIdx].IsEmpty)
                break;
            _firstFreeSlotIdx++;
        }
    }

    private bool FindIndexById(ItemId id, out int idx)
    {
        idx = -1;
        for(int i = 0; i < _slots.Count; i++)
        {
            if (id == _slots[i].Id)
            {
                idx = i;
                return true;
            }
        }

        return false;
    }
}

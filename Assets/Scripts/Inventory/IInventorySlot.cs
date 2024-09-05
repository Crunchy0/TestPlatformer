using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySlot
{
    public ItemId Id { get; }
    public int ItemsCount { get; }
    public int FreeSpace { get; }
    public bool IsEmpty { get; }
    
    public bool AddItems(ItemId config, int amount);
    public int RemoveItems(int amount);
}

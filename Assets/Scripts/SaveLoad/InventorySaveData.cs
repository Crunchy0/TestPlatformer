using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventorySaveData
{
    public int slotsCount;
    public InventorySlotSaveData[] slots;
}

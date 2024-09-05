using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public event Action<IInventorySlot> onItemAdded;
    public event Action<IInventorySlot> onItemRemoved;

    //public int SlotsCount { get => _inventory.SlotsCount; }
    public int SlotsCount { get => _slotsCountInit; }

    [SerializeField] [Min(1)] private int _slotsCountInit;
    [SerializeField] private string _itemLayerName;

    private int _itemLayer;
    private IInventory _inventory;

    private void Awake()
    {
        _itemLayer = LayerMask.NameToLayer(_itemLayerName);
        _inventory = new FixedInventory(_slotsCountInit);
    }

    private void OnTriggerEnter(Collider other)
    {
        var gameObject = other.gameObject;
        if (_itemLayer != gameObject.layer)
            return;

        if (!gameObject.TryGetComponent<ItemComponent>(out var item))
            return;

        AddItem(item.Config.Id);
        Destroy(gameObject);
    }

    private void AddItem(ItemId id)
    {
        if (!_inventory.TryAddItems(id, 1, out int index))
            return;
        if (!_inventory.GetSlot(index, out var slot))
            return;

        onItemAdded?.Invoke(slot);
    }

    private void UseItem()
    {

    }
}

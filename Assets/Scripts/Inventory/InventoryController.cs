using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

public class InventoryController : MonoBehaviour
{
    public event Action<IInventorySlot> onItemAdded;
    public event Action<IInventorySlot> onItemRemoved;

    //public int SlotsCount { get => _inventory.SlotsCount; }
    public int SlotsCount { get => _slotsCountInit; }

    [SerializeField] [Min(1)] private int _slotsCountInit;
    [SerializeField] private string _itemLayerName;
    [SerializeField] private Transform _owner;

    private int _itemLayer;
    private IInventory _inventory;

    private void Awake()
    {
        if (_owner == null)
            _owner = transform;
        _itemLayer = LayerMask.NameToLayer(_itemLayerName);
        _inventory = new FixedInventory(_slotsCountInit);
    }

    private void OnEnable()
    {
        InventorySlotUI.onClickItemUI += TryUseItem;
    }

    private void OnDisable()
    {
        InventorySlotUI.onClickItemUI -= TryUseItem;
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

    private void RemoveItem(ItemId id)
    {
        if (!_inventory.GetSlot(id, out var slot))
            return;
        if (_inventory.TryRemoveItems(id, 1) < 1)
            return;

        onItemRemoved?.Invoke(slot);
    }

    private void TryUseItem(ItemId id, InventoryController controller)
    {
        if (controller != this || !_inventory.Has(id))
            return;

        RemoveItem(id);

        if (!_owner.TryGetComponent<EffectApplier>(out var applier))
            return;

        ItemConfig config;
        if (!ItemConfigDatabase.Instance.GetConfig(id, out config))
            return;

        IStatsModifier effect = new StatsModifier(config.Effect);
        applier.ApplyEffect(effect);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] private InventoryController _invController;
    [SerializeField] private Transform _grid;
    [SerializeField] private GameObject _slotPrefab;

    void Start()
    {
        for(int i = 0; i < _invController.SlotsCount; i++)
        {
            Instantiate(_slotPrefab, _grid);
        }
    }

    private void OnEnable()
    {
        _invController.onItemAdded += InventoryUIAdd;
        _invController.onItemRemoved += InventoryUIRemove;
    }

    private void OnDisable()
    {
        _invController.onItemAdded -= InventoryUIAdd;
        _invController.onItemRemoved -= InventoryUIRemove;
    }

    private void InventoryUIAdd(IInventorySlot invSlot)
    {
        int firstEmpty = _grid.childCount;
        InventorySlotUI empty = null;

        for(int i = 0; i < _grid.childCount; i++)
        {
            var uiSlot = _grid.GetChild(i);
            if (!uiSlot.TryGetComponent<InventorySlotUI>(out var ui))
                continue;

            if (ui.ItemId == ItemId.NONE && firstEmpty > i)
            {
                firstEmpty = i;
                empty = ui;
            }

            if(ui.ItemId == invSlot.Id)
            {
                ui.Text.text = $"{invSlot.ItemsCount}";
                return;
            }
        }

        if(firstEmpty < _grid.childCount)
        {
            empty.ItemId = invSlot.Id;
            empty.Controller = _invController;
            empty.Text.text = $"{invSlot.ItemsCount}";
        }
    }

    private void InventoryUIRemove(IInventorySlot invSlot)
    {
        for(int i = 0; i < _grid.childCount; i++)
        {
            var uiSlot = _grid.GetChild(i);
            if (!uiSlot.TryGetComponent<InventorySlotUI>(out var ui))
                continue;

            if (ui.ItemId != invSlot.Id)
                continue;

            if(invSlot.IsEmpty)
            {
                ui.ItemId = ItemId.NONE;
                ui.Controller = null;
            }
            ui.Text.text = invSlot.IsEmpty ? "" : $"{invSlot.ItemsCount}"; ;
            break;
        }
    }
}

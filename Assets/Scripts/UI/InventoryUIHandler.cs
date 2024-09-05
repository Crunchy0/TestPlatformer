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
    }

    private void OnDisable()
    {
        _invController.onItemAdded -= InventoryUIAdd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InventoryUIAdd(IInventorySlot invSlot)
    {
        for(int i = 0; i < _grid.childCount; i++)
        {
            var slot = _grid.GetChild(i);
            if (!slot.TryGetComponent<InventorySlotUI>(out var ui))
                continue;

            if (ui.ItemId == ItemId.NONE)
                ui.ItemId = invSlot.Id;

            if (ui.ItemId != invSlot.Id)
                continue;
            else
                ui.Text.text = $"{invSlot.ItemsCount}";
            break;
        }
    }
}

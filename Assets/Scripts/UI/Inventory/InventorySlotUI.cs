using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IInventorySlotUI
{
    public static event Action<ItemId, InventoryController> onClickItemUI;

    public ItemId ItemId {
        get => _itemId;
        set
        {
            _itemId = value;
            _image.sprite = null;
            if (ItemConfigDatabase.Instance.GetConfig(value, out var config))
                _image.sprite = config.Icon;
        }
    }

    public InventoryController Controller { get; set; } = null;

    public Image Image { get => _image; }
    public Text Text { get => _text; }

    private ItemId _itemId;

    [SerializeField] private Image _image;
    [SerializeField] private Text _text;

    public void TriggerClickItemUI()
    {
        onClickItemUI?.Invoke(ItemId, Controller);
    }
}

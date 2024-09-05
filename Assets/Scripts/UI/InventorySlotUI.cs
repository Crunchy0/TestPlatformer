using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IInventorySlotUI
{
    public ItemId ItemId {
        get => _itemId;
        set
        {
            _itemId = value;
            if (ItemConfigDatabase.Instance.GetConfig(value, out var config))
                _image.sprite = config.Icon;
        }
    }

    public Image Image { get => _image; }
    public Text Text { get => _text; }

    private ItemId _itemId;

    [SerializeField] private Image _image;
    [SerializeField] private Text _text;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IInventorySlotUI
{
    public ItemConfig ItemConfig {
        get => _config;
        set
        {
            _config = value;
            _image.sprite = _config.Icon;
        }
    }

    public Image Image { get => _image; }
    public Text Text { get => _text; }

    private ItemConfig _config;

    [SerializeField] private Image _image;
    [SerializeField] private Text _text;
}

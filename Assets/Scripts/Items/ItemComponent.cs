using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    public ItemConfig Config { get => _config; }

    [SerializeField] private ItemConfig _config;
}

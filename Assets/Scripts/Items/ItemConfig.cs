using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item Config", menuName = "Scriptables/Item Config")]
public class ItemConfig : ScriptableObject
{
    public ItemId Id { get => _id; }
    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public ItemEffect Effect { get => _effect; }

    [SerializeField] private ItemId _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemEffect _effect;
}

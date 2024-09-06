using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

[CreateAssetMenu(fileName = "New Item Effect", menuName = "Scriptables/Item Effect")]
public class ItemEffect : ScriptableObject, IStats
{
    public float Health { get => _health; }
    public float Endurance { get => _endurance; }
    public float Strength { get => _strength; }
    public float Wisdom { get => _wisdom; }

    [SerializeField] private float _health;
    [SerializeField] private float _endurance;
    [SerializeField] private float _strength;
    [SerializeField] private float _wisdom;
}

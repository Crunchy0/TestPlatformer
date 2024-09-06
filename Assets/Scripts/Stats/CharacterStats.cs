using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

public class CharacterStats : MonoBehaviour
{
    public event Action<List<string>> onChangeStats;

    public IStats Stats { get => _stats; }

    [SerializeField] private BaseStats _baseStats;
    private Stats _stats;

    public void RequestStats()
    {
        onChangeStats?.Invoke(WriteStats());
    }

    private void Awake()
    {
        _stats = new(_baseStats);
    }

    void Start()
    {
        onChangeStats?.Invoke(WriteStats());
    }

    public void Modify(IStatsModifier modifier)
    {
        _stats.MergeModifier(modifier);
        onChangeStats?.Invoke(WriteStats());
    }

    private List<string> WriteStats()
    {
        List<string> strStats = new List<string>
        {
            $"Health: {_stats.Health}",
            $"Endurance: {_stats.Endurance}",
            $"Strength: {_stats.Strength}",
            $"Wisdom: {_stats.Wisdom}"
        };

        return strStats;
    }
}

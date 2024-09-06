using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

public class StatsModifier : IStatsModifier
{
    public float Health { get; private set; } = 0;
    public float Endurance { get; private set; } = 0;
    public float Strength { get; private set; } = 0;
    public float Wisdom { get; private set; } = 0;

    public static StatsModifier Neutral { get; } = new();

    private StatsModifier() { }

    public StatsModifier(IStats baseStats)
    {
        Health = baseStats.Health;
        Endurance = baseStats.Endurance;
        Strength = baseStats.Strength;
        Wisdom = baseStats.Wisdom;
    }

    public IStatsModifier Merge(IStatsModifier other)
    {
        var modifier = new StatsModifier(this);
        modifier.Health += other.Health;
        modifier.Endurance += other.Endurance;
        modifier.Strength += other.Strength;
        modifier.Wisdom += other.Wisdom;
        return modifier;
    }
}

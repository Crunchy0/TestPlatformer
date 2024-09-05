using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlatformer.Stats
{
    public class Stats : IStats
    {
        public IStats Base { get => _base; }
        public IStatsModifier Modifier { get; private set; }

        public float Health { get => Base.Health + Modifier.Health; }
        public float Endurance { get => Base.Endurance + Modifier.Endurance; }
        public float Strength { get => Base.Strength + Modifier.Strength; }
        public float Wisdom { get => Base.Wisdom + Modifier.Wisdom; }

        private readonly IStats _base;

        public Stats(BaseStats baseStats)
        {
            _base = baseStats;
            Modifier = new StatsModifier();
        }
    }
}

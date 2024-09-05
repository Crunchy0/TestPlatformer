using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlatformer.Stats
{
    public class StatsModifier : IStatsModifier
    {
        public float Health { get; set; }
        public float Endurance { get; set; }
        public float Strength { get; set; }
        public float Wisdom { get; set; }

        public StatsModifier()
        {
            Reset();
        }

        public void Reset()
        {
            Health = 0;
            Endurance = 0;
            Strength = 0;
            Wisdom = 0;
        }

        public void Merge(IStatsModifier other)
        {
            Health += other.Health;
            Endurance += other.Endurance;
            Strength += other.Strength;
            Wisdom += other.Wisdom;
        }
    }
}

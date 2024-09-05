using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlatformer.Stats
{
    public interface IStats
    {
        public float Health { get; }
        public float Endurance { get; }
        public float Strength { get; }
        public float Wisdom { get; }
    }
}

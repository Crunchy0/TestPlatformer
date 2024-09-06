using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlatformer.Stats
{
    public interface IStatsModifier : IStats
    {
        public IStatsModifier Merge(IStatsModifier other);
    }
}

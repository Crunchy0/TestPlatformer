using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlatformer.Stats
{
    [CreateAssetMenu(fileName ="New Stats", menuName ="Scriptables/Base Character Stats")]
    public class BaseStats : ScriptableObject, IStats
    {
        public float Health { get => _health; }
        public float Endurance { get => _endurance; }
        public float Strength { get => _strength; }
        public float Wisdom { get => _wisdom; }

        [SerializeField] [Min(0)] private float _health;
        [SerializeField] [Min(0)] private float _endurance;
        [SerializeField] [Min(0)] private float _strength;
        [SerializeField] [Min(0)] private float _wisdom;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private BaseStats _baseStats;
    private Stats _stats;

    private void Awake()
    {
        _stats = new(_baseStats);
    }

    void Start()
    {
        Debug.Log($"Stats are as follows:\nHealth: {_stats.Health},\nEndurance: {_stats.Endurance}\nStrength: {_stats.Strength}\nWisdom: {_stats.Wisdom}");
    }

    void Update()
    {
        // Update UI
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPlatformer.Stats;

[RequireComponent(typeof(CharacterStats))]
public class EffectApplier : MonoBehaviour
{
    private CharacterStats _stats;

    private void Start()
    {
        _stats = GetComponent<CharacterStats>();
    }

    public void ApplyEffect(IStatsModifier modifier)
    {
        _stats.Modify(modifier);
    }
}

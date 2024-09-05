using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private CharacterStats _statsHolder;
    [SerializeField] private GameObject _statLine;

    private CharacterStats _cachedStatsHolder;

    private void OnEnable()
    {
        _cachedStatsHolder = _statsHolder;
        _statsHolder.onChangeStats += UpdateUI;
    }

    private void OnDisable()
    {
        _statsHolder.onChangeStats -= UpdateUI;
    }

    private void UpdateUI(List<string> strStats)
    {
        for(int i = 0; i < strStats.Count; i++)
        {
            var line = i == transform.childCount ? Instantiate(_statLine, transform) : transform.GetChild(i).gameObject;
            if (!line.TryGetComponent<Text>(out var text))
                continue;
            text.text = strStats[i];
        }
    }

    private void Update()
    {
        if(_cachedStatsHolder != _statsHolder)
        {
            _cachedStatsHolder.onChangeStats -= UpdateUI;
            _cachedStatsHolder = _statsHolder;
            _cachedStatsHolder.onChangeStats += UpdateUI;
            _statsHolder.RequestStats();
        }
    }
}

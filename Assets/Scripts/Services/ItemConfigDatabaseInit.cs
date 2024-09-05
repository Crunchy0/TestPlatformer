using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConfigDatabaseInit : MonoBehaviour
{
    [SerializeField] private List<ItemConfig> _configList;

    private void Awake()
    {
        ItemConfigDatabase.Instance.Register(_configList);
    }
}

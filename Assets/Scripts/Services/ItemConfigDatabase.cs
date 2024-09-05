using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConfigDatabase
{
    public static ItemConfigDatabase Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ItemConfigDatabase();
            return _instance;
        }
    }

    private static ItemConfigDatabase _instance = null;

    private Dictionary<ItemId, ItemConfig> _db = new();

    private ItemConfigDatabase() { }

    public bool Contains(ItemId id)
    {
        return _db.ContainsKey(id);
    }

    public bool GetConfig(ItemId id, out ItemConfig config)
    {
        return _db.TryGetValue(id, out config);
    }

    public void Register(ItemConfig config)
    {
        if (_db.ContainsKey(config.Id))
            _db.Add(config.Id, config);
        else
            _db[config.Id] = config;
    }

    public void Register(List<ItemConfig> configList)
    {
        foreach (var config in configList)
            Register(config);
    }

    public void Discard(ItemId id)
    {
        if (_db.ContainsKey(id))
            _db.Remove(id);
    }

    public void Discard(List<ItemId> idList)
    {
        foreach (var id in idList)
            Discard(id);
    }
}

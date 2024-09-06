using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.IO;

public static class SaveLoadSystem
{
    public static string RelativePath { get; set; } = "save.bin";

    public static InventorySaveData InventoryData { get; private set; }

    private static SaveData _saveData;
    private static HashAlgorithm _hasher = SHA256.Create();
    private static BinaryFormatter _formatter = new();
    
    public static void SetInventoryData(InventorySaveData inventoryData)
    {
        InventoryData = inventoryData;

        MemoryStream stream = new();
        _formatter.Serialize(stream, InventoryData);
        _saveData.inventoryData = stream.GetBuffer();
        stream.Close();
    }

    public static void Save()
    {
        string path = Application.persistentDataPath + "/" + RelativePath;
        _saveData.hash = _hasher.ComputeHash(_saveData.inventoryData);

        FileStream stream = new(path, FileMode.Create);
        _formatter.Serialize(stream, _saveData);
        stream.Close();
    }

    public static void Load()
    {
        string path = Application.persistentDataPath + "/" + RelativePath;

        if (!File.Exists(path))
            throw new FileNotFoundException($"Save file {RelativePath} doesn't exist!");

        FileStream stream = new(path, FileMode.Open);
        SaveData saveData = (SaveData)_formatter.Deserialize(stream);
        stream.Close();

        byte[] hash = _hasher.ComputeHash(saveData.inventoryData);
        if (hash.Equals(saveData.hash))
            throw new CryptographicException($"Hash mismatch, {RelativePath} is corrupted!");

        _saveData = saveData;

        MemoryStream memStream = new();
        memStream.Write(_saveData.inventoryData);
        memStream.Position = 0;
        InventoryData = (InventorySaveData)_formatter.Deserialize(memStream);
    }
}

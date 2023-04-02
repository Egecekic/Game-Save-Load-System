using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<string> collectedItems;
    public InventorySaveData playerInventory;
    public PlayerData playerData;
    public SerializableDictionary<string,InventorySaveData> data;
    public SerializableDictionary<string, IteamPickUpData> activeIteam;

    public SaveData()
    {
        this.collectedItems = new List<string>();
        this.playerInventory = new InventorySaveData();
        this.playerData = new PlayerData();
        this.data = new SerializableDictionary<string, InventorySaveData>();
        this.activeIteam = new SerializableDictionary<string, IteamPickUpData>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    public static SaveData data;

    private void Awake()
    {
        data = new SaveData();
        SaveLoad.OnLoadGame += LoadData;
    }
    public static void SaveData() 
    {
        var saveData =data;
        SaveLoad.SaveGame(saveData);
    }
    public void DeletData()
    {
        SaveLoad.DeleteSaveData();
    }
    public static void LoadData(SaveData _data)
    {
        data = _data;
    }
    public static void TryLoadData()
    {
        SaveLoad.LoadGame();
        SaveLoad.LoadGame();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class SaveLoad 
{
    public static UnityAction OnSaveGame;
    public static UnityAction<SaveData> OnLoadGame;

    public const string SaveDirectory = "/SaveData/";
    public const string fileName = "SaveGame.sav";


    public static bool SaveGame(SaveData data)
    {
        OnSaveGame?.Invoke();
        var dir = Application.persistentDataPath + SaveDirectory;

        GUIUtility.systemCopyBuffer = dir;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(dir + fileName, json);

        
        return true;
    }
    public static SaveData LoadGame()
    {
        string fullPath = Application.persistentDataPath + SaveDirectory + fileName;
        SaveData tempData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);

            OnLoadGame?.Invoke(tempData);
        }
        else
        {
            Debug.LogError("Save File does not exist!");
        }

        return tempData;
    }

    internal static void DeleteSaveData()
    {
        string fullPath = Application.persistentDataPath + SaveDirectory + fileName;

        if (File.Exists(fullPath)) File.Delete(fullPath);
        
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    private PlayerData myData=new PlayerData();
    private PlayerHealth myHealth;
    private void Awake()
    {
        myHealth=GetComponent<PlayerHealth>();
        SaveLoad.OnLoadGame += LoadInventory;
    }

    private void LoadInventory(SaveData saveData)
    {
        this.myData = saveData.playerData;
        gameObject.transform.rotation= myData.PlayerRotation;
        gameObject.transform.position = myData.PlayerPosition;
        myHealth.health = myData.CurrnetHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            myData.PlayerRotation = gameObject.transform.rotation;
            myData.PlayerPosition = gameObject.transform.position;
            myData.CurrnetHealt = myHealth.health;

            SaveGameManager.data.playerData = new PlayerData(gameObject.transform.position, transform.rotation, myHealth.health);
        }
    }
}
[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public int CurrnetHealt;

    public PlayerData(Vector3 playerPosition, Quaternion playerRotation, int currnetHealt)
    {
        PlayerPosition = playerPosition;
        PlayerRotation = playerRotation;
        CurrnetHealt = currnetHealt;
    }
}
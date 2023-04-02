using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class UniqueID : MonoBehaviour
{
    [ReadOnly,SerializeField] string _id=Guid.NewGuid().ToString();

    [SerializeField]
    private static SerializableDictionary<string, GameObject> idDatabase=new SerializableDictionary<string, GameObject>();

    public string ID => _id;

    private void OnValidate()
    {
        if (idDatabase.ContainsKey(ID)) Generate();
        else idDatabase.Add(_id, this.gameObject);
    }
    private void OnDestroy()
    {
        if(idDatabase.ContainsKey(ID)) idDatabase.Remove(_id);
    }

    void Generate()
    {
        _id = Guid.NewGuid().ToString();
        idDatabase.Add(_id, this.gameObject);
    }
}

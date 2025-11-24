using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager_Test : MonoBehaviour
{
    public List<ItemBasic> itemBasics = new List<ItemBasic>();

    private void Awake()
    {
       // SetData();
    }

    private void SetData()
    {
        //ItemBasics _itemBasics = new();
        //_itemBasics.itemBasics = itemBasics;

        //string json = JsonUtility.ToJson(_itemBasics, true);
        //SaveData(json);
    }

    private void SaveData(string _json)
    {
        string path = Application.persistentDataPath + "/Inventory.json";
        File.WriteAllText(path, _json);

        Debug.Log("JSON 파일 저장 완료: " + path);
    }


}

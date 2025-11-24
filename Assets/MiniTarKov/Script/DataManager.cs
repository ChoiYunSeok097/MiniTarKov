using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Path
    private readonly string BackpackPath = "/Backpack.json";

    // instance
    public static DataManager instance;

    // Data
    public ItemDataContainer itemDataContainer;

    public InventoryDataList backpackDatas;

    private void Awake()
    {
        instance = this;

        //Test(BackpackPath);
        LoadBackpackData();
        //SaveBackpackData();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            SaveBackpackData();
    }

    private void Test(string _path)
    {
        InventoryDataList inventoryDataList = new();
        inventoryDataList.inventoryDatas.Add(new ItemData { ID = 1, count = 1 });
        inventoryDataList.inventoryDatas.Add(new ItemData { ID = 2, count = 1 });

        string json = JsonUtility.ToJson(inventoryDataList, true);
        JsonLoader.SaveJson(json, _path);
    }

    private void LoadBackpackData()
    {
        InventoryDataList inventoryDataList = JsonLoader.LoadJson<InventoryDataList>(BackpackPath);
        backpackDatas = inventoryDataList;

        foreach (var p in backpackDatas.inventoryDatas)
        {
            Debug.Log($"이름: {p.ID}, 갯수: {p.count}");
        }
    }
    private void SaveBackpackData()
    {
        //InventoryData[] inventoryDataList = new InventoryData[2];
        //inventoryDataList[0] = new InventoryData { ID = 1, count = 1 };
        //inventoryDataList[1] = new InventoryData {ID = 1, count = 1 };
                
        string json = JsonUtility.ToJson(UI_Manager.instance.inventory.GetInventoryList(), true);
        //string json = JsonUtility.ToJson(inventoryDataList, true);
        JsonLoader.SaveJson(json, BackpackPath);
    }

    private void LoadData(string _path)
    {
        //string path = Application.persistentDataPath + "/playerData.json";
        string path = Application.persistentDataPath + _path;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerDataList loadedList = JsonUtility.FromJson<PlayerDataList>(json);

            foreach (var p in loadedList.players)
            {
                Debug.Log($"이름: {p.playerName}, 레벨: {p.level}, 체력: {p.health}");
            }
        }
        else
        {
            Debug.LogWarning("저장된 파일이 없습니다.");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float health;
}
[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> players = new();
}
[System.Serializable]
public class ItemData
{
    public int ID;
    public int count;
}
[System.Serializable]
public class InventoryDataList
{
    public List<ItemData> inventoryDatas = new();
}

[System.Serializable]
public class Wrapper<T>
{
    public T[] dataArray;
}

public static class JsonLoader
{
    public static void SaveJson(string _json, string _path)
    {
        string path = Application.persistentDataPath + _path;
        File.WriteAllText(path, _json);

        Debug.Log("JSON 파일 저장 완료: " + path);
    }

    // 단일 객체 로드
    public static T LoadJson<T>(string _path)
    {
        string path = Application.persistentDataPath + _path;
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<T>(json);
    }
}
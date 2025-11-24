using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // BackPack
    public int backpackMaxCount = 20;
    public GameObject backpackSlotPrefeb;
    public Transform backpack;

    private InventoryDataList inventoryDataList;
    public int inventoryBlankSlotIndex;
    private List<InventorySlot> slotList;

    private void Awake()
    {
        slotList = new();

        inventoryBlankSlotIndex = 0;
    }

    private void Start()
    {
        SetInitBackpackSlot();
        SetInitBackpackData();
    }

    private void SetInitBackpackSlot()
    {
        if (backpackSlotPrefeb == null || backpack == null || backpackMaxCount == 0)
            return;

        inventoryDataList = DataManager.instance.backpackDatas;

        // Add Slot
        for (int i = 0; i < backpackMaxCount; i++)
        {
            InventorySlot newSlot = Instantiate(backpackSlotPrefeb, backpack).GetComponent<InventorySlot>();
            newSlot.index = i;
            slotList.Add(newSlot);
        }
    }

    private void SetInitBackpackData()
    {
        inventoryDataList = DataManager.instance.backpackDatas;

        int i = 0;
        for (; i< inventoryDataList.inventoryDatas.Count; i++)
        {
            ItemBasic item = DataManager.instance.itemDataContainer.GetItemById(inventoryDataList.inventoryDatas[i].ID);    // Get Data
            slotList[i].Init(inventoryDataList.inventoryDatas[i], item, i, this);                                           // Set Data in slot
        }

        // Set BlankSlot Index
        inventoryBlankSlotIndex = i;

        for (; i< backpackMaxCount; i++)
        {
            slotList[i].Init(i, this);
        }
    }

    public void SetSlotItem(int _index, SlotItem _slotItem)
    {
        if(inventoryDataList.inventoryDatas.Count <= _index)
        {
            inventoryDataList.inventoryDatas.Add(_slotItem.GetData());
        }
        else
        {
            inventoryDataList.inventoryDatas[_index] = _slotItem.GetData();
        }          
    }

    public void SwitchSlotItem(SlotBase A, SlotBase B)
    {
        // Switch Data
        ItemData _data = inventoryDataList.inventoryDatas[A.index];
        inventoryDataList.inventoryDatas[A.index] = inventoryDataList.inventoryDatas[B.index];
        inventoryDataList.inventoryDatas[B.index] = _data;
    }

    public void MoveSlotItem(SlotBase A, SlotBase B)
    {
        if (B.index >= inventoryBlankSlotIndex)
            return;     
    }

    public void AddSlotItem(SlotItem _slotItem)
    {
        if (inventoryBlankSlotIndex >= backpackMaxCount)
            return;

        inventoryDataList.inventoryDatas.Add(_slotItem.GetData());
        inventoryBlankSlotIndex++;
    }


    public InventoryDataList GetInventoryList()
    {
        return inventoryDataList;
    }
}

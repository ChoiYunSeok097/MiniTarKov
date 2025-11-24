using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private ItemDataContainer container;
    public List<ItemBasic> items;
    public List<ItemData> itemDatas;

    private void Start()
    {
        container = DataManager.instance.itemDataContainer;
        InitItems();
        InitItemDatas();
    }

    private void InitItems()
    {
        items = container.GetItems();
    }

    public void InitItemDatas()
    {
        itemDatas = new();
        for (int i = 0; i < items.Count; i++)
        {
            ItemData _itemData = new();
            _itemData.ID = items[i].ID;
            _itemData.count = items[i].Count;
            itemDatas.Add(_itemData);
        }
    }

    public void SetItemData(int _index, ItemData _itemData)
    {
        if(_index >= itemDatas.Count)
        {
            itemDatas.Add(_itemData);
        }
        else
        {
            itemDatas[_index] = _itemData;
        }
    }

    public List<ItemData> GetItemDatas()
    {
        return itemDatas;
    }
}

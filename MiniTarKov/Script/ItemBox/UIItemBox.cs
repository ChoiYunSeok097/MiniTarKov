
using System.Collections.Generic;
using UnityEngine;

public class UIItemBox : MonoBehaviour
{
    public List<ItemBoxSlot> itemBoxSlots;

    public void OpenUIItemBox(ItemBox _itemBox)
    {
        UI_Manager.instance.OpenUiItemBox();
    }

    public void SetItemSlot(ItemBox _itemBox)
    {
        if (_itemBox == null || itemBoxSlots.Count == 0)
            return;

        for (int i = 0; i < itemBoxSlots.Count; i++)
        {
            // Set Item
            if(i< _itemBox.itemDatas.Count)
            {
                itemBoxSlots[i].Init(_itemBox.itemDatas[i], _itemBox.items[i], i);
            }
        }
    }

    
}

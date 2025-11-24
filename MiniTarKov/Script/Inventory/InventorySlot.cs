using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class InventorySlot : SlotBase
{
    private Inventory inventory;

    public override void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.TryGetComponent<SlotItem>(out SlotItem _slotItem);

        if (_slotItem == null)
            return;

        // From Item Box
        if(_slotItem.slotBase.TryGetComponent<ItemBoxSlot>(out ItemBoxSlot _itemBoxSlot))
        {
            //AddSlotItem(_slotItem);
            MoveSlotItem(_itemBoxSlot);
        }
        // From Inventory
        else if(_slotItem.slotBase.TryGetComponent<InventorySlot>(out InventorySlot _inventorySlot))
        {
            //SwitchSlotItem(_slotItem, _inventorySlot);
        }
        else if (slotItem == null)
        {           
            //MoveItemSlot(_slotItem);
        }

    }
    public void Init(int _index, Inventory _inventory)
    {
        Init(index);

        inventory = _inventory;
    }

    public void Init(ItemData _data, ItemBasic _item, int _index, Inventory _inventory)
    {        
        Init(_data ,_item, index);

        inventory = _inventory;
    }

    public override void SetSlotItem(SlotItem _item)
    {
        base.SetSlotItem(_item);
        inventory.SetSlotItem(index, _item);
    }

    // From ItemBox
    public void MoveSlotItem(ItemBoxSlot _itemBoxSlot)
    {
        SlotItem _input = _itemBoxSlot.slotItem;

        // Switch slotItem
        if(slotItem != null)
        {
            _itemBoxSlot.SetSlotItem(slotItem);           
        }
        
        // Add Slot Item
        else
        {
            _itemBoxSlot.SetSlotItem(null);
        }
        SetSlotItem(_input);
    }






    // From Inventory
    protected void SwitchSlotItem(SlotItem _input, InventorySlot _inventorySlot)
    {
        if (inventory == null)
            return;

        _inventorySlot.SetSlotItem(slotItem);
        SetSlotItem(_input);
    }

//    protected override void MoveItemSlot(SlotItem _input)
//    {
//        if (inventory == null)
//            return;
//        if (this.index >= inventory.inventoryBlankSlotIndex)
//            return;
//;
//        base.MoveItemSlot(_input);
//    }

//    private void AddSlotItem(SlotItem _input)
//    {
//        if (inventory == null)
//            return;

//        inventory.AddSlotItem(_input);
//        base.MoveItemSlot(_input);
//    }
}

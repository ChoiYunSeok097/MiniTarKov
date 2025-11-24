using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBoxSlot : SlotBase
{
    private ItemBox ItemBox;
    public override void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.TryGetComponent<SlotItem>(out SlotItem _slotItem);

        if (_slotItem == null)
            return;

        //From Inventory
        if(_slotItem.slotBase.TryGetComponent<InventorySlot>(out InventorySlot _inventorySlot))
        {
            MoveSlotItem(_slotItem, _inventorySlot);
        }
    }

    public override void SetSlotItem(SlotItem _slotItem)
    {
        ItemData _input;
        if(_slotItem == null) _input = null;
        else _input = _slotItem.GetData();

        UI_Manager.instance.itemBox.SetItemData(index, _input);
        base.SetSlotItem(_slotItem);
    }

    public void MoveSlotItem(SlotItem _slotItem, InventorySlot _inventorySlot)
    {
        // Add SlotItem
        if(slotItem != null)
        {
            _inventorySlot.SetSlotItem(slotItem);
        }
        else
        {
            _inventorySlot.SetSlotItem(null);
        }
            SetSlotItem(_slotItem);
    }
}

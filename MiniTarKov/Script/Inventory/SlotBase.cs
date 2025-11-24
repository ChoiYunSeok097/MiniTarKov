using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBase : MonoBehaviour, IDropHandler
{
    public int index;

    public SlotItem slotItem;
    public GameObject slotItemPrefeb;
    
    public virtual void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.TryGetComponent<SlotItem>(out SlotItem _slotItem);

        if (slotItem == null)
        {
            //MoveItemSlot(_slotItem);
        }
        else if (_slotItem != null)
        {
            //SwitchSlotItem(_slotItem);
        }
    }
    public void Init(int _index)
    {
        index = _index;     
    }
    public void Init(ItemData _data, ItemBasic _item, int _index)
    {
        Init(_index);

        AddSlotItem(_data, _item);
    }

    public virtual void SetSlotItem(SlotItem _item)
    {
        if (_item == null)
        {
            slotItem = null;
        }
        else
        {
            slotItem = _item;
            _item.ChangeSlot(this);
        }
    }

    public void AddSlotItem(ItemData _data, ItemBasic _item)
    {
        if (slotItem == null)
            Instantiate(slotItemPrefeb, transform).TryGetComponent(out slotItem);

        if (slotItem != null)
        {
            slotItem.SetItemData(_data, _item);
        }
    }

    //public virtual void SetSlotItem(SlotItem _item)
    //{
    //    if(_item == null)
    //    {
    //        slotItem = null;
    //    }
    //    else
    //    {
    //        slotItem = _item;
    //        _item.ChangeSlot(this);
    //    }          
    //}

    //protected virtual void SwitchSlotItem(SlotItem _input)
    //{
    //    // Save Data
    //    SlotItem _slotItem = _input;

    //    // Switch Slot
    //    _input.slotBase.SetSlotItem(slotItem);
    //    SetSlotItem(_slotItem);
    //}

    //protected virtual void MoveItemSlot(SlotItem _input)
    //{
    //    // Slot
    //    SlotBase _slot = _input.slotBase;

    //    // Move slot
    //    SetSlotItem(_input);

    //    // Init Data       
    //    _slot.slotItem = null;
    //}
}

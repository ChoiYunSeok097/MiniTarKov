using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas parentCanvas;
    public SlotBase slotBase;

    private Image image;
    private ItemBasic Item;
    private ItemData data;

    private void Awake()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        transform.parent.TryGetComponent(out slotBase);

        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;

        transform.SetParent(parentCanvas.transform, true); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(slotBase.transform); // Slot으로 돌아가기
    }

    public void ChangeSlot(SlotBase _slot)
    {
        if (_slot == null)
            return;

        slotBase = _slot;
        transform.SetParent(slotBase.transform, true);
    }

    public void SetItemData(ItemData _data, ItemBasic _item)
    {
        data = _data;
        Item = _item;
        image.sprite = _item.sprite;
    }

    public ItemData GetData()
    {
        return data;
    }
}

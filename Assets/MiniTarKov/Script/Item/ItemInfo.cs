using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemBasic itemBasic;

    private int itemID;
    private string itemName;

    private string uiImagePath;

    private void Awake()
    {
        itemID = itemBasic.ID;
        itemName = itemBasic.Name;
        
    }
}

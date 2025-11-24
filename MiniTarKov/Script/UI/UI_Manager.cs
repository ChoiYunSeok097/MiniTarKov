using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public UI_ItemBoxMarkPool itemBoxMarkPool;
    public Inventory inventory;
    public UIItemBox uiItemBox;

    public ItemBox itemBox;

    private void Awake()
    {
        instance = this;
    }

    public void OpenInventory()
    {
        inventory.gameObject.SetActive(true);
    }

    public void OpenUiItemBox()
    {
        OpenInventory();
        uiItemBox.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        inventory.gameObject.SetActive(false);
        uiItemBox.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }
        
        if(Input.GetKeyDown(KeyCode.F) && itemBox != null)
        {
            OpenUiItemBox();
            uiItemBox.SetItemSlot(itemBox);
        }
    }
}

using UnityEngine;

public class ItemBox_ColliderEvent : MonoBehaviour
{
    private bool isTouch = false;
    public ItemBox ItemBox;

    private void OnCollisionEnter(Collision collision)
    {
        UI_Manager.instance.itemBox = ItemBox;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(UI_Manager.instance.itemBox == ItemBox)
            UI_Manager.instance.itemBox = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouch)
        {
            //UI_Manager.instance.uiItemBox.OpenUIItemBox(ItemBox);

        }
    }
}

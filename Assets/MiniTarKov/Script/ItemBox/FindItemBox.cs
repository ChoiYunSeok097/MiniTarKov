using UnityEngine;

public class FindItemBox : MonoBehaviour
{
    private string PlayerTag = "Player";

    private UI_ItemBoxMarkPool ui_itemBoxMarkPool;
    private UI_ItemBoxMark itemBox;

    private void Start()
    {
        ui_itemBoxMarkPool = UI_Manager.instance.itemBoxMarkPool;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(PlayerTag))
        {
            itemBox = ui_itemBoxMarkPool?.AddItemBoxUI(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(PlayerTag))
        {
            if (itemBox == null) return;

            ui_itemBoxMarkPool.ReleaseItemBoxUI(itemBox);
            itemBox = null;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ItemDataContainer : MonoBehaviour
{
    [SerializeField]
    private List<ItemBasic> Weapons;

    public ItemBasic GetItemById(int _ID)
    {
        return Weapons.Find(x => x.ID == _ID);
    }

    public List<ItemBasic> GetItems()
    {
        return Weapons;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Pool;

public class UI_ItemBoxMarkPool : MonoBehaviour
{
    [SerializeField]
    private GameObject itemBoxBase;
    [SerializeField]
    private Vector3 offset = Vector3.zero;

    private ObjectPool<UI_ItemBoxMark> itemBoxMarkPool;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

        itemBoxMarkPool = new ObjectPool<UI_ItemBoxMark>(CreateImageItemBox, OnGet, OnRelease, OnDestroyItemBox, maxSize: 7);
    }

    public UI_ItemBoxMark AddItemBoxUI(Transform _target)
    {
        if (_target == null) return null;

        UI_ItemBoxMark itemBox = itemBoxMarkPool.Get();
        itemBox.SetPropertise(_target, offset, mainCamera, this);
        itemBox.transform.SetParent(transform);

        return itemBox;
    }

    public void ReleaseItemBoxUI(UI_ItemBoxMark _itemBox)
    {
        itemBoxMarkPool.Release(_itemBox);
    }

    private UI_ItemBoxMark CreateImageItemBox()
    {
        if(itemBoxMarkPool == null) return null;

        UI_ItemBoxMark uI_ItemBox = Instantiate(itemBoxBase).GetComponent<UI_ItemBoxMark>();
        return uI_ItemBox;
    }

    private void OnGet(UI_ItemBoxMark _itembox)
    {
        _itembox.gameObject.SetActive(true);
    }

    private void OnRelease(UI_ItemBoxMark _itembox)
    {
        _itembox.gameObject.SetActive(false);
    }

    private void OnDestroyItemBox(UI_ItemBoxMark _itembox)
    {
        Destroy(_itembox.gameObject);
    }
}

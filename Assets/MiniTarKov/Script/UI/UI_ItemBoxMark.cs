using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Pool;

public class UI_ItemBoxMark : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    private Transform target;
    private Vector3 offset;
    private Camera cam;
    private UI_ItemBoxMarkPool controller;

    public void SetPropertise(Transform _target, Vector3 _offset, Camera _cam, UI_ItemBoxMarkPool _controller)
    {
        target = _target;        
        offset = _offset;
        cam = _cam;
        controller = _controller;
    }

    void LateUpdate()
    {
        SetPositionUI();      
    }
    
    private void SetPositionUI()
    {
        if (target == null) return;
        if (cam == null) return;
        if (rectTransform == null) return;

        Vector3 worldPos = target.position + offset;

        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);

        if (screenPos.z < 0)
        {
            rectTransform.gameObject.SetActive(false);
            return;
        }
        else
        {
            rectTransform.gameObject.SetActive(true);
        }

        rectTransform.position = screenPos;
    }
}

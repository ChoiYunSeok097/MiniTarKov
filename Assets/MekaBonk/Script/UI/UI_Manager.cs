using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public UI_ItemBoxMarkPool itemBoxMarkPool;

    private void Awake()
    {
        instance = this;
    }
}

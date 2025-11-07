using UnityEngine;

public class Gun : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            AddBullet();
        }
    }

    private void AddBullet()
    {
        if (BulletPool.instance == null) return;

        BulletPool.instance.AddBullet();
    }
}

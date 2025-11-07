using UnityEngine;

public class Gun : MonoBehaviour
{
    // Own
    public Character.Party Party;

    // Bullet
    public float shootTimeDistance = 0.1f;
    public int bulletNumMax = 20;

    private float BulletTimer = 0.0f;
    private float bulletNum = 0;

    private void Start()
    {
        bulletNum = bulletNumMax;
    }

    private void Update()
    {
        BulletTimer -= Time.deltaTime;

        ShootBullet();
        Reload();
    }
    private void ShootBullet()
    {       
        if (Input.GetMouseButton(0))
        {
            if (BulletTimer <= 0 && bulletNum > 0)
            {
                AddBullet(transform, Party);

                BulletTimer = shootTimeDistance;
                bulletNum--;
            }
        }
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletNum = bulletNumMax;
        }
    }

    private void AddBullet(Transform _transform, Character.Party _party)
    {
        if (BulletPool.instance == null) return;

        BulletPool.instance.AddBullet(_transform, _party);
    }
}

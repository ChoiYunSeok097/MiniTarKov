using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletBase;
    public static BulletPool instance;

    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        instance = this;

        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnDestroyBullet, maxSize: 20);
    }

    public Bullet AddBullet()
    {
        Bullet _bullet = bulletPool.Get();

        if (_bullet == null) return null;

        _bullet.transform.parent = transform;
        _bullet.bulletPool = bulletPool;

        return _bullet;
    }

    private Bullet CreateBullet()
    {
        if (bulletBase == null) return null;

        Instantiate(bulletBase).TryGetComponent<Bullet>(out Bullet _bullet);

        return _bullet;
    }

    private void OnGet(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet _bullet)
    {
        _bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet _bullet)
    {
        Destroy(_bullet);
    }
}

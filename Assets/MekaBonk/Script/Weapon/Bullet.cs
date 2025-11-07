using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;
    public ObjectPool<Bullet> bulletPool;

    private Rigidbody rb;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= lifeTime) OnRelease();

        transform.Translate(Vector3.forward * speed);
    }

    private void OnRelease()
    {
        if (bulletPool == null) return;

        bulletPool.Release(this);
    }
}


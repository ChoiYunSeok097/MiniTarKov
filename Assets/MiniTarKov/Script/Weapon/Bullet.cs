using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    // Layer
    private readonly int MapLayer = 11;
    private readonly int CharaterLayer = 7;

    // Owner
    public Character.Party party;

    public float speed = 20f;
    public float lifeTime = 2f;
    public float demage = 1f;

    private ObjectPool<Bullet> bulletPool;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(MapLayer))
        {
            OnRelease();
        }
        else if(other.gameObject.layer.Equals(CharaterLayer))
        {
            if (other.gameObject.TryGetComponent<Character>(out Character _char))
            {
                if (party == _char.party)
                    return;

                _char.GetDemage(demage);
                OnRelease();
            }
        }   
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

    public void Init(Transform _transform, ObjectPool<Bullet> _bulletPool, Character.Party _party)
    {       
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;

        bulletPool = _bulletPool;

        party = _party;
    }

    private void OnRelease()
    {
        if (bulletPool == null) return;

        bulletPool.Release(this);
    }
}


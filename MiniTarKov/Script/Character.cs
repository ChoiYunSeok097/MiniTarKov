using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public enum Party { Player, Enemy};
    public Party party;

    public float HP = 5f;
    public float moveSpeed = 5.0f;

    public abstract void Move();
    public abstract void Rotation();

    public abstract void GetDemage(float _demage);
    public abstract void Die();

}

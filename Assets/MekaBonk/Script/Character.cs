using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float HP = 5f;
    public float moveSpeed = 5.0f;

    public abstract void Move();
    public abstract void Rotation();

}

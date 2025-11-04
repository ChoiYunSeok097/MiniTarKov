using UnityEngine;

[RequireComponent(typeof(Movement_Player))]
public class Character_Player : Character
{
    private Movement_Player Movement_Player;

    private void Awake()
    {
        TryGetComponent(out Movement_Player);
    }

    private void Update()
    {
        Move();
        Rotation();
    }



    public override void Move()
    {
        if (Movement_Player == null) return;

        Movement_Player.Move( moveSpeed, Time.deltaTime);
    }

    public override void Rotation()
    {
        if (Movement_Player == null) return;

        Movement_Player.Rotation(transform);
    }
}

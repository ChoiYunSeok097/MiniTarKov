using UnityEngine;

public class Enemy : Character
{
    
    public override void Move()
    {
        
    }

    public override void Rotation()
    {
        
    }
    public override void Die()
    {
        gameObject.SetActive(false);
    }

    public override void GetDemage(float _demage)
    {
        HP -= _demage;

        if(HP <= 0)
        {
            Die();
        }
    }
}

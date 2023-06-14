using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Start()
    {
        base.Start();
        Health = base.health;
    }

    public override void DistanceToPlayer()
    {
        base.DistanceToPlayer();

        if (_isHit)
        {
            _enemyAN.SetTrigger("Attack");
            StartCoroutine(TimeToResetAnimation());
        }
        else
        {
            _enemyAN.ResetTrigger("Attack");
        }
    }


    public void Damage()
    {
        Debug.Log("Dañó al enemigo");
        _isHit = true;
        _enemyAN.SetTrigger("Hit");
        _enemyAN.SetBool("IsCombat", true);
        Health -= 1;
        Debug.Log(Health);
        if (Health < 1) Destroy(this.gameObject);
    }

    
   
}

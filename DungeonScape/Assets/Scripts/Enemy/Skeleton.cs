using System.Collections;
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
            StartCoroutine(TimeToResetAnimation());// no estoy seguro de que esto sea muy funcional 24/06/23
        }
        else
        {
            _enemyAN.ResetTrigger("Attack");
        }
    }


    public void Damage()
    {
        _isHit = true;

        _enemyAN.SetBool("IsCombat", true);
        if (Health == 0)
        {
            speed = 0;
            _enemyAN.SetTrigger("Dead");
            _getColliderToDesactivate.enabled = false;
            GemsRecolect();
            StartCoroutine(TimeToDestroy());
        }
        else
        {
            Health--;
            _enemyAN.SetTrigger("Hit");
        }
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(2.0F);
        Destroy(this.gameObject);
    }

    void GemsRecolect()
    {
        for(int i=1; i<=gems; i++)
        {
            Instantiate(_gems, transform.position, Quaternion.identity);
        }
    }
}

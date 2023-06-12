using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Start()
    {
        base.Start();
        Health = base.health;
    }
    

    public void Damage()
    {
        Debug.Log("Dañó al enemigo");
        _isHit = true;
        _enemyAN.SetTrigger("Hit");
        _enemyAN.SetBool("IsCombat", true);
        Health -= 1;
        if (Health<1) Destroy(this.gameObject);

    }
}

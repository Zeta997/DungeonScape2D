using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantScript : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Start()
    {
        base.Start();
        Health = base.health;
    }

    public void Damage()
    {

    }
}

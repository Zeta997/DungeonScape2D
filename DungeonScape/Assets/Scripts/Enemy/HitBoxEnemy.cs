using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemy : MonoBehaviour
{
    public Skeleton skeletonHit;
    public MossGiantScript mossgiantHit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
      IDamageable _player = other.GetComponent<IDamageable>();
        if (other.tag== "Player")
        {
            if(gameObject.name== "SkeletonHitBox")
            {
                other.GetComponent<Player>().enemyDamage = skeletonHit.strongHitEnemy;
                _player.Damage();

            }else if (gameObject.name == "MossGiantHitBox")
            {
                other.GetComponent<Player>().enemyDamage = mossgiantHit.strongHitEnemy;
                _player.Damage();
            }

        }
    }
}

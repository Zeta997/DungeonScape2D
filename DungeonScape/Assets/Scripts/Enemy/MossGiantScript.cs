using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantScript : Enemy
{
    #region components
    private Animator _EnemyIdle;
    private Vector2 _currenttarget;
    private SpriteRenderer _enemyMossGianFlip;
    #endregion
    public override void Start()
    {
        _EnemyIdle = GetComponentInChildren<Animator>();
        _enemyMossGianFlip = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Update()
    {
        //CheckingAnimations();
        if (_EnemyIdle.GetCurrentAnimatorStateInfo(0).IsName("MossGiantIdle"))
        {
            return;
        }
        MovementEnemy();
    }

    public override void Attack()
    {
        base.Attack();

        //avanced attack
    }
    void CheckingAnimations()
    {
        

    }

    void MovementEnemy()
    {
        if (transform.position.x== _pointA.position.x)
        {
            
            _enemyMossGianFlip.flipX = false;
            _currenttarget = _pointB.position;
            _EnemyIdle.SetTrigger("Idle");
        }
        else if (transform.position.x == _pointB.position.x)
        {
            
            _enemyMossGianFlip.flipX = true;
            _currenttarget = _pointA.position;
            _EnemyIdle.SetTrigger("Idle");
        } 
        transform.position = Vector2.MoveTowards(transform.position, _currenttarget, speed*Time.deltaTime);
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region variables
    [Header("variables Enemy")]
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    
    #endregion

    #region Components
    [Header("Componentes")]
    [SerializeField] protected Transform _pointA, _pointB;
    protected Vector2 _currentTarget;
    protected SpriteRenderer _spriteEnemy;
    protected Animator _enemyAN;
    #endregion
    public virtual void Start()
    {
        _spriteEnemy = GetComponentInChildren<SpriteRenderer>();
        _enemyAN = GetComponentInChildren<Animator>();
    }
    public virtual void Attack()
    {
        //base attack
    }

    public virtual void Update()
    {
        if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        MovementEnemy();
    }

    

    public virtual void MovementEnemy()
    {
        if (transform.position == _pointA.position)
        {

            _spriteEnemy.flipX = false;
            _currentTarget = _pointB.position;
            _enemyAN.SetTrigger("Idle");
        }
        else if (transform.position == _pointB.position)
        {

            _spriteEnemy.flipX = true;
            _currentTarget = _pointA.position;
            _enemyAN.SetTrigger("Idle");
        }
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}

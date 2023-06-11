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
    [SerializeField] protected bool _isHit;

    #endregion

    #region Components
    [Header("Componentes")]
    [SerializeField] protected Transform _playerTransform;
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
        if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !_enemyAN.GetBool("IsCombat"))
        {
            return;
        }else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("IdleCombat"))
        {
            return;
        }
        else
        {
            if (DistanceToPlayer() <= 2 || _isHit) { _enemyAN.SetBool("IsCombat", true); }
            if (DistanceToPlayer() >= 3) { _isHit = false; _enemyAN.SetBool("IsCombat", false);}
            
        }
        MovementEnemy();
        //DistanceToPlayer();
        //if (DistanceToPlayer() <= 2 || _isHit) { _enemyAN.SetBool("IsCombat", true); }
        //if(DistanceToPlayer() > 2) { Debug.Log("Modo combate OFF"); _isHit = false; _enemyAN.SetBool("IsCombat", false); }
    }
    
    public int DistanceToPlayer()
    {
        Vector2 distanceVector = _playerTransform.position - transform.position;
        int result =(int)Mathf.Abs(Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2)));
        return result;
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

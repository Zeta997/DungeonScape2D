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
    int distanceToPlayer;
    #endregion

    #region Components
    [Header("Componentes")]
    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected Transform _pointA, _pointB;
    protected Vector2 _currentTarget;
    protected SpriteRenderer _spriteEnemy;
    protected Animator _enemyAN;
    protected Vector2 _directionLook;
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

        _directionLook = _playerTransform.localPosition - transform.localPosition;

        if (distanceToPlayer <= 2 || _isHit) { _enemyAN.SetBool("IsCombat", true); }
        if (distanceToPlayer >= 3) { _isHit = false; _enemyAN.SetBool("IsCombat", false);}

        distanceToPlayer = (int) Vector2.Distance(transform.position,_playerTransform.position);
        LookAt();

        if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !_enemyAN.GetBool("IsCombat"))
        {
            return;
        }else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Hit") && _enemyAN.GetBool("IsCombat"))
        {
            return;

        }else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("IdleCombat") && distanceToPlayer<=2)
        {
            return;
        }
        MovementEnemy();
    }

    public virtual void LookAt()
    {
        _directionLook =_playerTransform.localPosition - transform.localPosition;
        if (_enemyAN.GetBool("IsCombat") && _directionLook.x < 0) _spriteEnemy.flipX = true;
        
        else if (_enemyAN.GetBool("IsCombat") && _directionLook.x > 0) _spriteEnemy.flipX = false;
        
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

using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region variables
    [Header("variables Enemy")]
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    protected int gems=3;
    [SerializeField] protected bool _isHit;
    protected double distanceToPlayer;
    [SerializeField] protected double _distanciaLimit;
    #endregion

    #region Components
    [Header("Componentes")]
    [SerializeField] protected Transform _playerTransform;
    [SerializeField] protected Transform _pointA, _pointB;
    [SerializeField] protected GameObject _gems;
    protected BoxCollider2D _getColliderToDesactivate;
    protected Transform _spriteRotation;
    protected Vector2 _currentTarget;
    protected SpriteRenderer _spriteEnemy;
    protected Animator _enemyAN;
    protected Vector2 _directionLook;
    #endregion
    public virtual void Start()
    {
        _getColliderToDesactivate = GetComponent<BoxCollider2D>();
        _spriteEnemy = GetComponentInChildren<SpriteRenderer>();
        _enemyAN = GetComponentInChildren<Animator>();
        _spriteRotation = GetComponent<Transform>();
    }
    public virtual void Attack()
    {
        //base attack
    }

    public virtual void Update()
    {
        DistanceToPlayer();
        LookAt();
        if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }
        else if (_enemyAN.GetCurrentAnimatorStateInfo(0).IsName("IdleCombat"))
        {
            return;
        }

        if (!_enemyAN.GetBool("IsCombat")) MovementEnemy();

    }

    public virtual void DistanceToPlayer()
    {
        distanceToPlayer = Math.Round(Vector2.Distance(transform.position, _playerTransform.position), 1);

        if (distanceToPlayer <= _distanciaLimit)
        {
            _enemyAN.SetBool("IsCombat", true);
        }
        else if (distanceToPlayer >= _distanciaLimit)
        {
            _enemyAN.SetBool("IsCombat", false);
        }
    }

    public virtual void LookAt()
    {

        _directionLook = _playerTransform.localPosition - transform.localPosition;

        if (_enemyAN.GetBool("IsCombat"))
        {
            if (_spriteRotation.rotation.y == 0 && _directionLook.x < 0.1) { _spriteEnemy.flipX = true; }
            else if (_spriteRotation.rotation.y == 0 && _directionLook.x > 0.1) { _spriteEnemy.flipX = false; }

            if (_spriteRotation.rotation.y == 1 && _directionLook.x > 0.1) { _spriteEnemy.flipX = true; }
            else if (_spriteRotation.rotation.y == 1 && _directionLook.x < 0.1) { _spriteEnemy.flipX = false; }
        }

        if (!_enemyAN.GetBool("IsCombat"))
        {
            if (_spriteRotation.rotation.y == 1) _spriteEnemy.flipX = false;
            else if (_spriteRotation.rotation.y == 0) _spriteEnemy.flipX = false;
        }

    }

    public virtual void MovementEnemy()
    {
        if (transform.position == _pointA.position)
        {
            _spriteRotation.rotation = Quaternion.Euler(0, 0, 0);
            _currentTarget = _pointB.position;
            _enemyAN.SetTrigger("Idle");
        }
        else if (transform.position == _pointB.position)
        {
            _spriteRotation.rotation = Quaternion.Euler(0, 180, 0);
            _currentTarget = _pointA.position;
            _enemyAN.SetTrigger("Idle");
        }
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }

    public IEnumerator TimeToResetAnimation()
    {
        yield return new WaitForSeconds(1.0F);
        _isHit = false;
    }
}

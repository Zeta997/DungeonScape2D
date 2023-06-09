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
    //[SerializeField] protected bool switchpoint;
    #endregion

    #region Components
    [Header("Componentes")]
    [SerializeField] protected Transform _pointA, _pointB;
    #endregion

    public virtual void Attack()
    {
        //base attack
    }

    public abstract void Update();

    public abstract void Start();
}

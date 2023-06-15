using UnityEngine;
public class Spider : Enemy, IDamageable
{
    #region variables
    public int Health { get; set; }
    public GameObject acid;
    #endregion

    public override void Start()
    {
        base.Start();
        Health = base.health;
    }

    public override void LookAt()
    {
        base.LookAt();
        if (_directionLook.x > -3.5 && _directionLook.x < 3.5)
        {
            if (_directionLook.x < 0)
            {
                _spriteRotation.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (_directionLook.x > 0)
            {
                _spriteRotation.rotation = Quaternion.Euler(0, 0, 0);
            }
            _enemyAN.SetBool("IsCombat", true);
        }
    }
    public void Damage()
    {
        Health -= 1;
        Debug.Log($"{gameObject.name} fue dañado");
    }


    public override void Attack()
    {
        base.Attack();
        Instantiate(acid, transform.position, Quaternion.identity);
    }
}

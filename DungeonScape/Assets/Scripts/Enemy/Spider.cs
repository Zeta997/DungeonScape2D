using System.Collections;
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
        if (Health == 0)
        {
            _enemyAN.SetTrigger("Dead");
            _getColliderToDesactivate.enabled = false;
            StartCoroutine(TimeToDestroy());
        }
        else
        {
            Health--;
            _enemyAN.SetTrigger("Hit");
        }
    }


    public override void Attack()
    {
        base.Attack();
        Instantiate(acid, transform.position, Quaternion.identity);
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(2.0F);
        Destroy(this.gameObject);
    }
}

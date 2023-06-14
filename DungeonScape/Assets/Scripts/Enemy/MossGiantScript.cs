using UnityEngine;
public class MossGiantScript : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Start()
    {
        base.Start();
        Health = base.health;
    }
    public override void MovementEnemy()
    {
        base.MovementEnemy();
        //marcamos un rango para determinar la posicion a la que tiene que ir
        if (_directionLook.x > -3.5 && _directionLook.x < 3.5)
        {

            if (_directionLook.x < 0)
            {
                _currentTarget = _pointA.position;

            }
            else if (_directionLook.x > 0)
            {
                _currentTarget = _pointB.position;               
            }
        }
        
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
            
        }

    }
    public void Damage()
    {
        Debug.Log(gameObject.name);
        _enemyAN.SetTrigger("Hit");
    }
}

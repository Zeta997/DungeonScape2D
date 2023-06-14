using UnityEngine;
public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
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
    public void Damage() { }
}

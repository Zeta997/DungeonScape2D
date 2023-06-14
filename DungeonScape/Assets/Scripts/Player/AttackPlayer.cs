using System.Collections;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    #region variables
    [SerializeField] bool _canDamage;
    #endregion

    private void Start()
    {
        _canDamage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable _enemyHit = collision.GetComponent<IDamageable>();

        if (collision != null)
        {
            StartCoroutine(CoolDown());
            if (_canDamage) { _enemyHit.Damage(); _canDamage = false; }
        }
    }

    IEnumerator CoolDown()
    {

        yield return new WaitForSeconds(0.5F);
        _canDamage = true;
    }
}

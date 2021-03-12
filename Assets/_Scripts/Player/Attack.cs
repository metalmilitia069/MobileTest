using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private int _weaponDamage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hitItem = collision.GetComponent<IDamageable>();

      
        if (hitItem != null)
        {
            if (_canDamage == true)
            {
                hitItem.Damage(_weaponDamage);
                _canDamage = false;                
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}

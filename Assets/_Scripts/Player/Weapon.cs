using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private bool _canDamage = true;
    [SerializeField]
    private int _weaponDamage = 1;    

    public void DamageHandle(IDamageable damageable)
    {
        if (_canDamage == true)
        {
            damageable.Damage(_weaponDamage);            
            Debug.Log("CU");
            _canDamage = false;
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}

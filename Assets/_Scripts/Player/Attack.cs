using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private int _weaponDamage = 1;
    [SerializeField]
    private GameObject _weaponObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hitItem = collision.GetComponent<IDamageable>();

      
        if (hitItem != null)
        {
            _weaponObject.GetComponent<Weapon>().DamageHandle(hitItem);
            //if (_canDamage == true)
            //{
                //hitItem.Damage(_weaponDamage);
                //this.gameObject.SetActive(false);
                //Debug.Log("CU");
                //StartCoroutine(ResetDamage());
                //_canDamage = false;                
            //}
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}

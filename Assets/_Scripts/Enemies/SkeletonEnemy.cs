using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy, IDamageable
{

    public override void Init()
    {
        base.Init();
        Health = base.health;        
    }
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        _monsterAnimator.SetTrigger("Hit");
        isHit = true;
        _monsterAnimator.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            _monsterAnimator.SetTrigger("Death");
            Destroy(this.gameObject, 5.0f);
        }
    }
}

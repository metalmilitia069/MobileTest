using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantEnemy : Enemy, IDamageable
{

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        if (isDead)
        {
            return;
        }

        Health -= damageAmount;
        _monsterAnimator.SetTrigger("Hit");
        isHit = true;
        _monsterAnimator.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            _monsterAnimator.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 5.0f);
        }
    }


































    //private bool _switch = false;

    //private Vector3 _currentTarget;

    //private Animator _monsterAnimator;
    //private SpriteRenderer _monsterSprite;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _monsterAnimator = GetComponentInChildren<Animator>();
    //    _monsterSprite = GetComponentInChildren<SpriteRenderer>();
    //}

    //public override void Update()
    //{
    //    if (_monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("MossGiant_Ene_Idle"))
    //    {
    //        return;
    //    }




    //}


    //public override void Update()
    //{
    //    if (_monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("MossGiant_Ene_Idle"))
    //    {
    //        return;
    //    }

    //    if (_currentTarget == pointA.position)
    //    {
    //        _monsterSprite.flipX = true;
    //    }
    //    else
    //    {
    //        _monsterSprite.flipX = false;
    //    }

    //    Movement2();
    //}

    //    void Movement()
    //{
    //    if (transform.position == pointA.position)
    //    {
    //        _switch = false;
    //        //transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
    //    }
    //    else if (transform.position == PointB.position)
    //    {
    //        //transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    //        _switch = true;
    //    }

    //    if (_switch == false)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
    //    }
    //    else if (_switch == true)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    //    }
    //}

    //void Movement2()
    //{
    //    if (transform.position == pointA.position)
    //    {
    //        _currentTarget = PointB.position;
    //        _monsterAnimator.SetTrigger("Idle");            
    //        //transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
    //    }
    //    else if (transform.position == PointB.position)
    //    {
    //        _currentTarget = pointA.position;
    //        _monsterAnimator.SetTrigger("Idle");            
    //        //transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

    //    }

    //    transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    //}


}

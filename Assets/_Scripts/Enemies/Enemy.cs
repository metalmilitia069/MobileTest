using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, PointB;

    protected Vector3 _currentTarget;
    protected Animator _monsterAnimator;
    protected SpriteRenderer _monsterSprite;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        _monsterAnimator = GetComponentInChildren<Animator>();
        _monsterSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Movement()
    {
        

        //


        if (transform.position == pointA.position)
        {
            _currentTarget = PointB.position;
            _monsterAnimator.SetTrigger("Idle");            
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = pointA.position;
            _monsterAnimator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

    public virtual void Update()
    {
        if (_monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("MossGiant_Ene_Idle") || _monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spider_Ene_Idle") || _monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_Ene_Idle"))
        {
            return;
        }

        if (_currentTarget == pointA.position)
        {
            _monsterSprite.flipX = true;
        }
        else
        {
            _monsterSprite.flipX = false;
        }

        Movement();
    }

}

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

    protected bool isHit = false;

    protected Player player;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        _monsterAnimator = GetComponentInChildren<Animator>();
        _monsterSprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {     
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

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f)
        {
            isHit = false;
            _monsterAnimator.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - this.transform.localPosition;
        if (_monsterAnimator.GetBool("InCombat"))
        {
            if (direction.x < 0)
            {
                _monsterSprite.flipX = true;
            }
            else if (direction.x > 0)
            {
                _monsterSprite.flipX = false;
            }
        }
    }

    public virtual void Update()
    {
        if (_monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("MossGiant_Ene_Idle") || _monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spider_Ene_Idle") || _monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_Ene_Idle") && !_monsterAnimator.GetBool("InCombat"))
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

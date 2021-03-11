using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArc;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArc = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void JumpAnimation(bool isJumping)
    {
        _anim.SetBool("Jumping", isJumping);
        //Debug.Log("Jumping? " + isJumping);
    }

    public void AttackAnimation()
    {
        _anim.SetTrigger("BasicAttack");
        _swordArc.SetTrigger("SwordAnimation");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.5f;
    [SerializeField]
    private bool _grounded = false; //DELETE LATER
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private LayerMask GroundLayer;
    [SerializeField]
    private int _playerHealth = 4;

    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordArcSpriteRenderer;

    public int diamonds = 0;

    public int Health { get; set; }

    private PlayerController _playerController;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = _playerHealth;
        _playerController = GetComponent<PlayerController>();
        _playerController.GetPlayerControls().Land.Jump.performed += _ => Jump();
        _playerController.GetPlayerControls().Land.Attack.performed += _ => Attack();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //if (Input.GetMouseButtonDown(0) && _rigid.velocity.y == 0) ///////////////////////////////////////////////////////////////
        //{
        //    _playerAnimation.AttackAnimation();
        //}

        if (_rigid.velocity.y == 0)
        {
            _playerAnimation.JumpAnimation(false);
        }
    }

    public void Attack()
    {
        if (_rigid.velocity.y == 0)
        {
            _playerAnimation.AttackAnimation();
        }
    }

    private void Movement()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal"); //////////////////////////////////////////////////////////////////////////////
        //FlipCharacter(horizontalInput);

        //if (Input.GetKeyDown(KeyCode.Space)) ////////////////////////////////////////////////////////////////////////////////////////////
        //{
        //    RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, GroundLayer);

        //    if (hitInfo.collider)
        //    {
        //        _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        //        _playerAnimation.JumpAnimation(true);
        //    }
        //}

        //_rigid.velocity = new Vector2(horizontalInput * _speed, _rigid.velocity.y);
        //_playerAnimation.Move(horizontalInput);
        //if (_rigid.velocity.y == 0)
        //{
        //    _playerAnimation.JumpAnimation(false);            
        //}

        FlipCharacter(_playerController.movementInput);

        _rigid.velocity = new Vector2(_playerController.movementInput * _speed, _rigid.velocity.y);
        _playerAnimation.Move(_playerController.movementInput);

    }

    public void Jump()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, GroundLayer);

        if (hitInfo.collider)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _playerAnimation.JumpAnimation(true);
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            _playerSpriteRenderer.flipX = false;
            _swordArcSpriteRenderer.flipX = false;
            _swordArcSpriteRenderer.flipY = false;

            Vector3 newPos = _swordArcSpriteRenderer.transform.localPosition;
            newPos.x = Mathf.Abs(newPos.x);
            _swordArcSpriteRenderer.transform.localPosition = newPos;
        }
        else if (horizontalInput < 0)
        {
            _playerSpriteRenderer.flipX = true;
            _swordArcSpriteRenderer.flipX = true;
            _swordArcSpriteRenderer.flipY = true;
            Vector3 newPos = _swordArcSpriteRenderer.transform.localPosition;
            //_ = (newPos.x < 0) ? newPos.x : (newPos.x = (newPos.x * -1));
            newPos.x = (newPos.x < 0) ? newPos.x : newPos.x * -1;
            _swordArcSpriteRenderer.transform.localPosition = newPos;            
        }
    }

    public void Damage(int damageAmount)
    {
        if (Health < 1)
        {
            return;
        }

        Health -= damageAmount;
        UIManager.Instance.UpdateLives(Health);
        Debug.Log("Healh = " + Health);
        //_monsterAnimator.SetTrigger("Hit");
        //isHit = true;
        //_monsterAnimator.SetBool("InCombat", true);

        if (Health < 1)
        {
            //this.GetComponentInChildren<Animator>().SetTrigger("Death");
            _playerAnimation.Death();
            //Destroy(this.gameObject);
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
}

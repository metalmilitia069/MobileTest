using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _grounded = false; //DELETE LATER
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private LayerMask GroundLayer;

    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0) && _rigid.velocity.y == 0)
        {
            _playerAnimation.AttackAnimation();
        }


    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        FlipCharacter(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, GroundLayer);

            if (hitInfo.collider)
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
                _playerAnimation.JumpAnimation(true);
            }
        }

        _rigid.velocity = new Vector2(horizontalInput * _speed, _rigid.velocity.y);
        _playerAnimation.Move(horizontalInput);
        if (_rigid.velocity.y == 0)
        {
            _playerAnimation.JumpAnimation(false);            
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}

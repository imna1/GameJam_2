using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public bool IsPaused;

    //Просто переменные
    protected float _horizontal;
    protected float _lastGroundedTime;
    protected bool _canMove;
    [SerializeField] protected float _coyoteTime;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected AudioClip _diyingSound;
    [SerializeField] protected AudioClip _jumpSound;
    [SerializeField] protected AudioClip _walkSound;

    //Компоненты
    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _spriteRenderer;
    protected Animator _animator;
    protected SoundManager _soundManager;


    public virtual void Respawn()
    {
        _canMove = true;
    }
    protected virtual void Start()
    {
        _soundManager = SoundManager.Instance;
        _canMove = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("horizontal", Mathf.Abs(_horizontal));
        _animator.SetBool("isGrounded", _lastGroundedTime > 0);

        if(Physics2D.OverlapCircle(_groundCheck.position, 0.13f, _groundLayer))
        {
            _lastGroundedTime = _coyoteTime;
        }

        //Прыжок
        Jump();
        //Поворот игрока при смене стороны движения
        Flip();

        _lastGroundedTime -= Time.deltaTime;
    }

    protected virtual void FixedUpdate()
    {
        //Передвижение игрока
        if (_canMove)
            _rigidbody.velocity = new Vector2(_horizontal * _speed, _rigidbody.velocity.y);
        else
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }

    protected virtual void Jump()
    {
        if (Input.GetButtonDown("Jump") && _lastGroundedTime > 0f && _canMove)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.SetBool("isUp", true);
            //_soundManager.PlayAudio(_jumpSound);
        }
        if (_rigidbody.velocity.y < 0)
        {
            _animator.SetBool("isUp", false);
        }
    }

    protected virtual void Flip()
    {
        if (!_canMove || IsPaused)
            return;
        if (_horizontal == -1)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_horizontal == 1)
        {
            _spriteRenderer.flipX = false;
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            _canMove = false;
            //_soundManager.PlayAudio(_diyingSound);
            GameManager.Instance.OnPlayerDied();
        }
        if (collision.tag == "Finish")
        {
            _canMove = false;
            GameManager.Instance.NextLevel();
        }
    }
}

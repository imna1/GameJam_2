using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController18 : PlayerController
{
    private bool _isDragging;
    private Camera _cam;
    private Vector2 _direction;
    public override void Respawn()
    {
    }
    protected override void Start()
    {
        _cam = Camera.main;
        _soundManager = SoundManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("horizontal", Mathf.Abs(_horizontal));
        _animator.SetBool("isGrounded", _lastGroundedTime > 0);

        if (Physics2D.OverlapCircle(_groundCheck.position, 0.13f, _groundLayer))
        {
            _lastGroundedTime = _coyoteTime;
        }
    }
    
    private void OnMouseDrag()
    {
        _direction = (Vector2)(_cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }
    private void OnMouseUp()
    {
        _isDragging = false;
    }
    private void OnMouseDown()
    {
        _isDragging = true;
    }
    protected override void FixedUpdate()
    {
        if(_isDragging)
            _rigidbody.AddForce(_direction.normalized * _speed);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            _canMove = false;
            _soundManager.PlayAudio(_diyingSound);
            GameManager.Instance.OnPlayerDied();
            OnMouseUp();
        }
        if (collision.tag == "Finish")
        {
            _canMove = false;
            GameManager.Instance.NextLevel();
        }
    }
    protected override void Jump()
    {
    }
}

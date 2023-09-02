using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController15 : PlayerController
{
    protected override void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _horizontal = 1;
        else if (Input.GetKey(KeyCode.D))
            _horizontal = -1;
        else
            _horizontal = 0;
        _animator.SetFloat("horizontal", Mathf.Abs(_horizontal));
        _animator.SetBool("isGrounded", _lastGroundedTime > 0);

        if (Physics2D.OverlapCircle(_groundCheck.position, 0.13f, _groundLayer))
        {
            _lastGroundedTime = _coyoteTime;
        }

        Jump();
        Flip();

        _lastGroundedTime -= Time.deltaTime;
    }
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.A) && _lastGroundedTime > 0f && _canMove)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.SetBool("isUp", true);
            _soundManager.PlayAudio(_jumpSound);
        }
        if (_rigidbody.velocity.y < 0)
        {
            _animator.SetBool("isUp", false);
        }
    }
}

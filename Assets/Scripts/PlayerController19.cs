using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController19 : PlayerController
{
    protected override void Jump()
    {
        if (_lastGroundedTime > 0f && _canMove)
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

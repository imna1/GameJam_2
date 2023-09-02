using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController13 : PlayerController
{
    protected override void Jump()
    {
        if (Input.GetButtonDown("Jump") && _lastGroundedTime > 0f && _canMove && !IsPaused)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_jumpForce);
            _animator.SetBool("isUp", true);
            _soundManager.PlayAudio(_jumpSound, Random.Range(0.8f, 1.2f));
        }
        if (_rigidbody.velocity.y > 0)
        {
            _animator.SetBool("isUp", false);
        }
    }
}

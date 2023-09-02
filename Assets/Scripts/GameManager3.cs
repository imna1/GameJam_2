using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : GameManager
{
    protected override void Start()
    {
        _doorAnimator.Play("DoorOpen");
        base.Start();
    }
    public override void TurnOnLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOn);
        _isLeverPressed = true;
        _leverRenderer.sprite = _leverSprites[1];
        _doorAnimator.Play("DoorCycle");
    }
    public override void Restart()
    {
        UnPause();
        TurnOffLewer();
        _doorAnimator.Play("DoorOpen");
        _player.position = _playerStartPosition.position;
        _playerController.Respawn();
    }
}

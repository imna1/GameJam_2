using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager16 : GameManager
{
    [SerializeField] private string _animName;
    [SerializeField] private float _seconds;
    public override void TurnOnLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOn);
        _isLeverPressed = true;
        _leverRenderer.sprite = _leverSprites[1];
        _doorAnimator.Play(_animName);
        Invoke("TurnOffLewer", _seconds);
    }
    public override void TurnOffLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOff);
        _isLeverPressed = false;
        _leverRenderer.sprite = _leverSprites[0];
        _doorAnimator.Play("DoorCycle");
    }
}

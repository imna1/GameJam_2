using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager11 : GameManager
{
    private int _count;
    public override void Restart()
    {
        base.Restart();
        _count = 0;
    }
    public override void TurnOnLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOn);
        _isLeverPressed = true;
        _leverRenderer.sprite = _leverSprites[1];
        Invoke("TurnOffLewer", 1);
        _count++;
        if(_count == 5)
            _doorAnimator.Play("DoorOpen");
    }
}

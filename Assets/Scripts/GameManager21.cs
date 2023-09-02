using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager21 : GameManager2
{
    private int _count;
    public override void TurnOnLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOn);
        int closestLeverIndex = 0;
        float minDst = Vector2.Distance(_player.position, _levers[0].position);
        for (int i = 1; i < _levers.Length; i++)
        {
            if (Vector2.Distance(_player.position, _levers[i].position) < minDst)
            {
                closestLeverIndex = i;
                minDst = Vector2.Distance(_player.position, _levers[i].position);
            }
        }
        _isLeversPressed[closestLeverIndex] = true;
        _leverRenderers[closestLeverIndex].sprite = _leverSprites[1];
        Invoke("TurnOffLewer", 0.5f);
        if(closestLeverIndex == _count)
        {
            _count++;
        }
        if(_count >= 3)
            _doorAnimator.Play("DoorOpen");
    }
    public override void TurnOffLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOff);
        int closestLeverIndex = 0;
        float minDst = Vector2.Distance(_player.position, _levers[0].position);
        for (int i = 1; i < _levers.Length; i++)
        {
            if (Vector2.Distance(_player.position, _levers[i].position) < minDst)
            {
                closestLeverIndex = i;
                minDst = Vector2.Distance(_player.position, _levers[i].position);
            }
        }
        _isLeversPressed[closestLeverIndex] = false;
        _leverRenderers[closestLeverIndex].sprite = _leverSprites[0];
    }
}

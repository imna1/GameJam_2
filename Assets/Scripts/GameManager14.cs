using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager14 : GameManager
{
    [SerializeField] private GameObject _doorCollider;
    protected override bool CheckLever()
    {
        if (Vector2.Distance(_player.position, _lewer.position) < _maxDstBtwPlayerAndLewer)
            return true;
        else
            return false;
    }
    public override void TurnOnLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOn);
        _leverRenderer.sprite = _leverSprites[0];
        _doorCollider.SetActive(false);
    }
    public override void TurnOffLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOff);
        _leverRenderer.sprite = _leverSprites[1];
        _doorCollider.SetActive(true);
    }
}

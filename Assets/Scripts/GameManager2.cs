using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : GameManager
{
    [SerializeField] protected SpriteRenderer[] _leverRenderers;
    [SerializeField] protected Transform[] _levers;
    protected bool[] _isLeversPressed;

    protected override void Start()
    {
        _isLeversPressed = new bool[_levers.Length];
        base.Start();
    }
    protected override bool CheckLever()
    {
        for (int i = 0; i < _levers.Length; i++)
        {
            if (!_isLeversPressed[i] && Vector2.Distance(_player.position, _levers[i].position) < _maxDstBtwPlayerAndLewer)
                return true;
        }
        return false;
    }
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
        foreach (var item in _isLeversPressed)
        {
            if (!item)
                return;
        }
        _doorAnimator.Play("DoorOpen");
    }
    public override void TurnOffLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOff);
        for (int i = 0; i < _levers.Length; i++)
        {
            _isLeversPressed[i] = false;
            _leverRenderers[i].sprite = _leverSprites[0];
        }
    }
}

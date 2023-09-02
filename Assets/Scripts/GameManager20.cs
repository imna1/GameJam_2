using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager20 : GameManager
{
    [SerializeField] private Transform _gearPos;
    private bool _isSolved;

    protected override void Start()
    {
        base.Start();
        _doorAnimator.Play("DoorWithoutGear");
    }
    protected override bool CheckLever()
    {
        if (!_isLeverPressed && Vector2.Distance(_player.position, _lewer.position) < _maxDstBtwPlayerAndLewer && _isSolved)
            return true;
        else
            return false;
    }
    public override void Restart()
    {
        UnPause();
        TurnOffLewer();
        _doorAnimator.Play("DoorWithoutGear");
        _player.position = _playerStartPosition.position;
        _playerController.Respawn();
        _isSolved = false;
    }
    public override bool CheckDistance(Vector2 pos)
    {
        if(Vector2.Distance(pos, _gearPos.position) < 1)
        {
            _isSolved = true;
            _doorAnimator.Play("DoorCycle");
        }
        return _isSolved;
    }
}

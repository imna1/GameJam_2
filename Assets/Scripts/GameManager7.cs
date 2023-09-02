using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager7 : GameManager
{
    private bool _isPlayerDied;
    protected override bool CheckLever()
    {
        if (!_isLeverPressed && Vector2.Distance(_player.position, _lewer.position) < _maxDstBtwPlayerAndLewer && _isPlayerDied)
            return true;
        else
            return false;
    }
    public override void Restart()
    {
        _isPlayerDied = false;
        UnPause();
        _player.position = _playerStartPosition.position;
        _playerController.Respawn();
    }
    public override void OnPlayerDied()
    {
        _isPlayerDied = true;
        Invoke("Restart", 1f);
    }
}

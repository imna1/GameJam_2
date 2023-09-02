using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager9 : GameManager
{
    public override void UnPause()
    {
        CloseOptions();
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _playerController.IsPaused = false;
        if(_scrollBarMusic.value <= 0 && _scrollBarSound.value <= 0)
            TurnOnLewer();
    }
    protected override void Start()
    {
        base.Start();
        if (_scrollBarMusic.value <= 0 && _scrollBarSound.value <= 0)
            TurnOnLewer();
    }
}

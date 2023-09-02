using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager12 : GameManager11
{
    public override void GoToMenu()
    {
        PlayerPrefs.SetInt("LevelReached", ++_currentLevel);
        base.GoToMenu();
    }
    public override void TurnOnLewer()
    {
        _soundManager.PlayAudio(_lewerTurnOn);
        _isLeverPressed = true;
        _leverRenderer.sprite = _leverSprites[1];
        Invoke("TurnOffLewer", 1);
    }
}

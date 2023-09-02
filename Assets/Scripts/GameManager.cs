using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] protected int _currentLevel;
    [SerializeField] protected float _maxDstBtwPlayerAndLewer;
    [SerializeField] protected GameObject _pausePanel;
    [SerializeField] protected GameObject _lewerButton;
    [SerializeField] protected GameObject _optionsPanel;
    [SerializeField] protected Transform _lewer;
    [SerializeField] protected Transform _player;
    [SerializeField] protected Transform _playerStartPosition;
    [SerializeField] protected Text _musicValueText;
    [SerializeField] protected Text _soundValueText;
    [SerializeField] protected Scrollbar _scrollBarMusic;
    [SerializeField] protected Scrollbar _scrollBarSound;
    [SerializeField] protected AudioClip _lewerTurnOn;
    [SerializeField] protected AudioClip _lewerTurnOff;
    [SerializeField] protected SpriteRenderer _leverRenderer;
    [SerializeField] protected Sprite[] _leverSprites; //0 - неактив, 1 - актив, 2 - влево, 5 - вниз, 6 - сломан
    [SerializeField] protected Animator _doorAnimator;

    protected SoundManager _soundManager;
    protected PlayerController _playerController;
    protected bool _isLeverPressed;

    protected void Awake()
    {
        Instance = this;
    }
    protected virtual void Start()
    {
        _soundManager = SoundManager.Instance;
        _scrollBarMusic.value = _soundManager.GetVolumeMusic();
        _musicValueText.text = Mathf.Round(_scrollBarMusic.value * 100) + "%";
        _scrollBarSound.value = _soundManager.GetVolumeSound();
        _soundValueText.text = Mathf.Round(_scrollBarSound.value * 100) + "%";
        _player.position = _playerStartPosition.position;
        _playerController = _player.GetComponent<PlayerController>();
    }
    protected virtual void Update()
    {
        if(CheckLever())
        {
            _lewerButton.SetActive(true);
        }
        else
        {
            _lewerButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_pausePanel.activeSelf)
                UnPause();
            else
                Pause();
        }
    }
    protected virtual bool CheckLever()
    {
        if (!_isLeverPressed && Vector2.Distance(_player.position, _lewer.position) < _maxDstBtwPlayerAndLewer)
            return true;
        else
            return false;
    }
    public virtual void Pause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _playerController.IsPaused = true;
    }
    public virtual void UnPause()
    {
        CloseOptions();
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _playerController.IsPaused = false;
    }
    public virtual void Restart()
    {
        UnPause();
        TurnOffLewer();
        _doorAnimator.Play("DoorCycle");
        _player.position = _playerStartPosition.position;
        _playerController.Respawn();
    }
    public virtual void GoToMenu()
    {
        UnPause();
        SceneManager.LoadScene(0);
    }
    public virtual void NextLevel()
    {
        PlayerPrefs.SetInt("LevelReached", ++_currentLevel);
        SceneManager.LoadScene(_currentLevel);
    }
    public virtual void TurnOnLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOn);
        _isLeverPressed = true;
        _leverRenderer.sprite = _leverSprites[1];
        _doorAnimator.Play("DoorOpen");
    }
    public virtual void TurnOffLewer()
    {
        //_soundManager.PlayAudio(_lewerTurnOff);
        _isLeverPressed = false;
        _leverRenderer.sprite = _leverSprites[0];
    }
    public virtual void OpenOptions()
    {
        _optionsPanel.SetActive(true);
    }
    public virtual void CloseOptions()
    {
        _optionsPanel.SetActive(false);
    }
    public virtual void ChangeMusicVolume()
    {
        _soundManager.SetVolumeMusic(_scrollBarMusic.value);
        _musicValueText.text = Mathf.Round(_scrollBarMusic.value * 100) + "%";
    }
    public virtual void ChangeSoundVolume()
    {
        _soundManager.SetVolumeSound(_scrollBarSound.value);
        _soundValueText.text = Mathf.Round(_scrollBarSound.value * 100) + "%";
    }
    public virtual void OnPlayerDied()
    {
        Invoke("Restart", 1f);
    }
}

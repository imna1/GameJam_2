using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text _musicValueText;
    [SerializeField] private Text _soundValueText;
    [SerializeField] private Scrollbar _scrollBarMusic;
    [SerializeField] private Scrollbar _scrollBarSound;
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private Button[] _levelButtons;

    private SoundManager _soundManager;
    private void Start()
    {
        _soundManager = SoundManager.Instance;
        _soundManager = SoundManager.Instance;
        _scrollBarMusic.value = _soundManager.GetVolumeMusic();
        _musicValueText.text = Mathf.Round(_scrollBarMusic.value * 100) + "%";
        _scrollBarSound.value = _soundManager.GetVolumeSound();
        _soundValueText.text = Mathf.Round(_scrollBarSound.value * 100) + "%";
        int buttonIndex = PlayerPrefs.GetInt("LevelReached", 1);
        for (int i = 0; i < buttonIndex; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
    public void OpenLevelPanel()
    {
        _levelPanel.SetActive(true);
    }
    public void OpenOptions()
    {
        _optionsPanel.SetActive(true);
    }
    public void CloseLevelPanel()
    {
        _levelPanel.SetActive(false);
    }
    public void CloseOptions()
    {
        _optionsPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ChangeMusicVolume()
    {
        _soundManager.SetVolumeMusic(_scrollBarMusic.value);
        _musicValueText.text = Mathf.Round(_scrollBarMusic.value * 100) + "%";
    }
    public void ChangeSoundVolume()
    {
        _soundManager.SetVolumeSound(_scrollBarSound.value);
        _soundValueText.text = Mathf.Round(_scrollBarSound.value * 100) + "%";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_levelPanel.activeSelf)
                CloseLevelPanel();
            if (_optionsPanel.activeSelf)
                CloseOptions();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceMusic;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
       audioSourceMusic.Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void SetVolumeSound(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetVolumeMusic(float volume)
    {
        audioSourceMusic.volume = volume;
    }
    public float GetVolumeSound()
    {
        return audioSource.volume;
    }
    public float GetVolumeMusic()
    {
        return audioSourceMusic.volume;
    }
}

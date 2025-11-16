using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource oneShotSFXSource;
    [SerializeField] private AudioSource sFXSource;
    [SerializeField] private float defaultVolume = 0.3f;
    [SerializeField] private AudioClip[] playerSounds;

    // [SerializeField] private AudioClip backgroundMusic;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        sFXSource.volume = defaultVolume;
        // if (backgroundMusic != null)
        // {
        //     backgroundMusicSource.clip = backgroundMusic;
        //     backgroundMusicSource.Play();
        // }
    }

    public void PlayOneShot(AudioClip clip)
    {
        Instance.oneShotSFXSource.PlayOneShot(clip, defaultVolume);
    }

    public void Play(AudioClip clip)
    {
        sFXSource.clip = clip;
        sFXSource.Play();
    }

    public void Stop()
    {
        sFXSource.Stop();
        sFXSource.clip = null;
    }
}

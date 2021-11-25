using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        sfxSource.loop = false;
        musicSource.loop = true;
    }

    public void PlayAudioCue(AudioClip clip)
    {
        sfxSource.pitch = 1;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.pitch = 1;
        musicSource.clip = clip;
        musicSource.Play();
    }
}

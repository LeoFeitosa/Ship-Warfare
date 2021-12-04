using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioClip musicMainMenu;

    [SerializeField] float speedBackground = 1;

    void Awake()
    {
        if (!AudioController.Instance.MusicIsPlaying())
        {
            AudioController.Instance.PlayMusic(musicMainMenu);
        }
    }

    void Start()
    {
        Time.timeScale = speedBackground;
    }

    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }

    public void PlayAudio(AudioClip soundButton)
    {
        AudioController.Instance.PlayAudioCue(soundButton);
    }
}

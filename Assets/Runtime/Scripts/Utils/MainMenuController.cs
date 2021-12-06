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
        if (AudioController.Instance != null && !AudioController.Instance.MusicIsPlaying())
        {
            AudioController.Instance.PlayMusic(musicMainMenu);
        }
    }

    void Start()
    {
        Time.timeScale = speedBackground;
    }
}

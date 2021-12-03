using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] float speedBackground = 1;

    void Start()
    {
        Time.timeScale = speedBackground;
    }

    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }

    public void PlayAudioButton(AudioClip soundButton)
    {
        AudioController.Instance.PlayAudioCue(soundButton);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }

    public void PlayAudioButton(AudioClip soundButton)
    {
        AudioController.Instance.PlayAudioCue(soundButton);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsEffectsController : MonoBehaviour
{
    public void PlayAudio(AudioClip soundButton)
    {
        AudioController.Instance.PlayAudioCue(soundButton);
    }

    public void PlayMusic(AudioClip soundMusic)
    {
        AudioController.Instance.PlayMusic(soundMusic);
    }

    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }
}

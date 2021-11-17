using UnityEngine;

public class AudioUtility
{
    public static AudioController AudioController { private get; set; }

    public static void PlayAudioCue(AudioClip clip)
    {
        AudioController.Instance.PlayAudioCue(clip);
    }

    public static void PlayMusic(AudioClip clip)
    {
        AudioController.Instance.PlayMusic(clip);
    }
}

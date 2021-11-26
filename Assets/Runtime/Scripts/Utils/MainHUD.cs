using System.Collections;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioClip musicGameplay;

    [Header("Sounds")]
    [SerializeField] AudioClip soundBipCount;
    [SerializeField] AudioClip soundBipGo;

    [Header("Overlays")]
    [SerializeField] GameObject gameoverOverlay;
    [SerializeField] GameObject countdownOverlay;

    [Header("UI Elements")]
    [SerializeField] GameObject playerInfo;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] int countdownSeconds;
    [SerializeField] float textAnimationTime = 1f;
    [SerializeField] float textAnimationScaleSize = 10;
    public bool IsCountSeconds { get; private set; }

    void Awake()
    {
        IsCountSeconds = true;
    }

    void ShowHudOverlay()
    {
        playerInfo.SetActive(true);
    }

    public void GameOverActive()
    {
        gameoverOverlay.SetActive(true);
    }

    public IEnumerator ShowCountdown()
    {
        AudioController.Instance.PlayMusic(musicGameplay);
        countdownOverlay.SetActive(true);
        playerInfo.SetActive(false);
        gameoverOverlay.SetActive(false);

        yield return new WaitForSeconds(1);

        while (countdownSeconds > 0)
        {
            countdownText.text = countdownSeconds.ToString();
            AudioController.Instance.PlayAudioCue(soundBipCount);
            yield return new WaitForSeconds(1);
            countdownSeconds--;
            IsCountSeconds = true;
        }

        AudioController.Instance.PlayAudioCue(soundBipGo);
        countdownText.text = "GO!";

        //animacao
        float animationDuration = textAnimationTime;
        while (animationDuration >= 0)
        {
            countdownText.transform.localScale = Vector3.Lerp(
                countdownText.transform.localScale,
                countdownText.transform.localScale * textAnimationScaleSize,
                animationDuration
                );
            animationDuration -= Time.deltaTime;
            yield return new WaitForSeconds(animationDuration);
        }

        countdownOverlay.SetActive(false);
        playerInfo.SetActive(true);
        IsCountSeconds = false;
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
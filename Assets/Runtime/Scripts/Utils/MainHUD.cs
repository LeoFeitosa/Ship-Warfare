using System.Collections;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioClip musicGameplay;

    [Header("Overlays")]
    [SerializeField] GameObject gameoverOverlay;
    [SerializeField] GameObject countdownOverlay;

    [Header("UI Elements")]
    [SerializeField] GameObject playerInfo;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] int countdownSeconds;
    [SerializeField] float perdurationOfTextAnimationcent = 1f;
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
        countdownOverlay.SetActive(true);
        playerInfo.SetActive(false);
        gameoverOverlay.SetActive(false);

        yield return new WaitForSeconds(1);

        while (countdownSeconds > 0)
        {
            countdownText.text = countdownSeconds.ToString();
            yield return new WaitForSeconds(1);
            countdownSeconds--;
            IsCountSeconds = true;
        }

        AudioController.Instance.PlayMusic(musicGameplay);

        countdownText.text = "GO!";

        float animationDuration = perdurationOfTextAnimationcent;
        while (animationDuration >= 0)
        {
            //animacao
            countdownText.transform.localScale = Vector3.Lerp(countdownText.transform.localScale, countdownText.transform.localScale * 10, animationDuration);
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
}
using System.Collections;
using TMPro;
using UnityEngine;

public class MainHUD : MonoBehaviour
{
    [Header("Overlays")]
    [SerializeField] private GameObject gameoverOverlay;
    [SerializeField] private GameObject countdownOverlay;

    [Header("UI Elements")]
    [SerializeField] private GameObject playerInfo;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] int countdownSeconds;

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

        while (countdownSeconds > 0)
        {
            countdownText.text = Mathf.FloorToInt(countdownSeconds).ToString();
            yield return new WaitForSeconds(1);
            countdownSeconds--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1);

        countdownOverlay.SetActive(false);
        playerInfo.SetActive(true);
    }

    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }
}
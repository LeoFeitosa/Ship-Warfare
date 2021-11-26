using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILivesController : MonoBehaviour
{
    [SerializeField] Color[] colorLiveBar;
    [SerializeField] Image imageLiveBar;
    static PlayerController playerController;
    float percentageBar;
    [SerializeField] float timeToRemoveLife = 1.5f;
    [SerializeField] float timeToMergeColors = 2;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        GameObject liveBar = GameObject.FindWithTag("LiveBar");
        if (liveBar != null)
        {
            imageLiveBar = liveBar.GetComponent<Image>(); ;
        }

        if (colorLiveBar != null)
        {
            percentageBar = 1f / (colorLiveBar.Length - 1);
        }
    }

    void LateUpdate()
    {
        SetColorBar(playerController.Lives);
        SetSizeBar(playerController.Lives);
    }

    void SetColorBar(int color)
    {
        imageLiveBar.color = Color.Lerp(imageLiveBar.color, colorLiveBar[color], timeToMergeColors * Time.deltaTime);
    }

    void SetSizeBar(float value)
    {
        float percentageFillAmount = percentageBar * value;
        imageLiveBar.fillAmount = Mathf.Lerp(imageLiveBar.fillAmount, percentageFillAmount, timeToRemoveLife * Time.deltaTime);
    }
}

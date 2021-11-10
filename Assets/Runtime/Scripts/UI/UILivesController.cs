using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILivesController : MonoBehaviour
{
    [SerializeField] Color[] colorLiveBar;
    Image imageLiveBar;
    static PlayerController playerController;
    float percentageBar;
    [SerializeField] float timeToRemoveLife = 1.5f;
    [SerializeField] float timeToMergeColors = 2;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        GameObject backgroundLive = GameObject.FindWithTag("BackgroundLive");
        if (backgroundLive != null)
        {
            imageLiveBar = backgroundLive.GetComponent<Image>(); ;
        }

        if (colorLiveBar != null)
        {
            percentageBar = 1f / (colorLiveBar.Length - 1);
        }
    }

    void LateUpdate()
    {
        switch (playerController.Lives)
        {
            case 4:
                SetColorBar(4);
                SetSizeBar(4);
                break;
            case 3:
                SetColorBar(3);
                SetSizeBar(3);
                break;
            case 2:
                SetColorBar(2);
                SetSizeBar(2);
                break;
            case 1:
                SetColorBar(1);
                SetSizeBar(1);
                break;
            case 0:
                SetColorBar(0);
                SetSizeBar(0);
                break;
        }
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

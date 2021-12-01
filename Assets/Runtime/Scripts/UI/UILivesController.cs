using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILivesController : MonoBehaviour
{
    [SerializeField] Color[] colorLiveBar;
    [SerializeField] Image lifeBar;
    float percentageBar;
    [SerializeField] float timeToRemoveLife = 1.5f;
    [SerializeField] float timeToMergeColors = 2;
    int lifesCount = 1;

    void Start()
    {
        lifeBar.fillAmount = lifesCount;

        if (colorLiveBar.Length > 0)
        {
            percentageBar = 1f / (colorLiveBar.Length - 1);
        }
    }

    void LateUpdate()
    {
        SetColorBar();
        SetSizeBar();
    }

    void SetColorBar()
    {
        lifeBar.color = Color.Lerp(lifeBar.color, colorLiveBar[lifesCount], timeToMergeColors * Time.deltaTime);
    }

    void SetSizeBar()
    {
        float percentageFillAmount = percentageBar * lifesCount;
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, percentageFillAmount, timeToRemoveLife * Time.deltaTime);
    }

    public void SetLifesToUI(int lifes)
    {
        lifesCount = lifes;
    }
}

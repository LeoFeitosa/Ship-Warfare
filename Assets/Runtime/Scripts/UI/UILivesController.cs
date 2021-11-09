using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILivesController : MonoBehaviour
{
    [SerializeField] Color[] colorLiveBar;
    Image liveBar;
    GameObject playerController;
    int currentLives;
    Image currentColorBar;

    void Start()
    {
        playerController = GameObject.FindWithTag("Player");
        if (playerController != null)
        {
            //currentLives = playerController.GetComponent<PlayerController>();
        }

        GameObject backgroundLive = GameObject.FindWithTag("BackgroundLive");
        if (backgroundLive != null)
        {
            liveBar = backgroundLive.GetComponent<Image>(); ;
        }
    }

    void LateUpdate()
    {
        //currentLives = 2;

        switch (GetComponent<PlayerController>().Lives)
        {
            case 4:
                liveBar.GetComponent<Image>().color = colorLiveBar[4];
                break;
            case 3:
                liveBar.GetComponent<Image>().color = colorLiveBar[3];
                break;
            case 2:
                liveBar.GetComponent<Image>().color = colorLiveBar[2];
                break;
            case 1:
                liveBar.GetComponent<Image>().color = colorLiveBar[1];
                break;
            case 0:
                liveBar.GetComponent<Image>().color = colorLiveBar[0];
                break;
        }

        Debug.Log(currentLives);
    }
}

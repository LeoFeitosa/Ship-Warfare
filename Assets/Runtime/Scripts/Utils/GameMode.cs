using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    GameObject mainHUDObject;
    MainHUD mainHUD;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        StartCoroutine(mainHUD.ShowCountdown());
    }
}
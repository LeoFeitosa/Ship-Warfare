using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public static GameMode Instance;
    GameObject mainHUDObject;
    MainHUD mainHUD;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        StartCoroutine(mainHUD.ShowCountdown());
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void SlowMotion()
    {
        Time.timeScale = 0.5f;
    }
}
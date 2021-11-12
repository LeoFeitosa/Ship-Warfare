using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public static GameOverController Instance;
    [SerializeField] GameObject gameOverScreen;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }

    public void GameOverActive()
    {
        gameOverScreen.SetActive(true);
    }
}

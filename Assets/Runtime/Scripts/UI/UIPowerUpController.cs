using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerUpController : MonoBehaviour
{
    [SerializeField] Image powerUpBar;

    void Start()
    {
        powerUpBar.fillAmount = 0;
    }

    void LateUpdate()
    {
        SetPowerUpBar();
    }

    public void SetPowerUpBar()
    {
        powerUpBar.fillAmount = PowerUpsController.PowerUpDuration;
    }
}

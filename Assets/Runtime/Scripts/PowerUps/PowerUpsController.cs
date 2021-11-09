using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    [SerializeField] float duration = 2;
    public static float PowerUpDuration { get; private set; }
    bool timerIsRunning = false, initTimerIsRunning = false;
    ShotsTypesController shotsTypes;

    void FixedUpdate()
    {
        InitTimerPowerUp();
        TimerPowerUp();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            shotsTypes = col.gameObject.GetComponentInParent<ShotsTypesController>();

            if (shotsTypes == null)
            {
                Debug.LogError("Não foi possivel encontrar o gameObject ShotsTypesController");
            }
            else
            {
                initTimerIsRunning = true;

                if (gameObject.tag == "PowerUpShotTriple")
                {
                    PowerUpTriple();
                }

                if (gameObject.tag == "PowerUpShotDouble")
                {
                    PowerUpDouble();
                }

                if (gameObject.tag == "PowerUpOneMoreLife")
                {
                    PowerUpOneMoreLife();
                }
            }
        }
    }

    void PowerUpOneMoreLife()
    {
        Debug.Log("Mais uma vida");
        Destroy(gameObject);
    }

    void PowerUpNormal()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Normal;
    }

    void PowerUpDouble()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Double;
        StartPowerUp();
    }

    void PowerUpTriple()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Triple;
        StartPowerUp();
    }

    void StartPowerUp()
    {
        HideObject();
        timerIsRunning = true;
    }

    void HideObject()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    void TimerPowerUp()
    {
        if (timerIsRunning && !initTimerIsRunning)
        {
            float percent = 1.0f / duration * Time.fixedDeltaTime;
            PowerUpDuration -= percent;
            if (PowerUpDuration <= 0.02f)
            {
                PowerUpDuration = 0;
                PowerUpNormal();
                Destroy(gameObject);
            }
        }
    }

    void InitTimerPowerUp()
    {
        if (initTimerIsRunning)
        {
            float percent = 1.0f / 0.2f * Time.fixedDeltaTime;
            PowerUpDuration += percent;
            if (PowerUpDuration >= 1)
            {
                PowerUpDuration = 1;
                initTimerIsRunning = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    [SerializeField] float duration = 2;
    public float PowerUpDuration { get; private set; }
    bool timerIsRunning = false;
    ShotsTypesController shotsTypes;

    void Start()
    {
        PowerUpDuration = duration + 1;
    }

    void FixedUpdate()
    {
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
        StartCoroutine(TimeToInterruptPowerUp());
    }

    void PowerUpTriple()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Triple;
        StartCoroutine(TimeToInterruptPowerUp());
    }

    IEnumerator TimeToInterruptPowerUp()
    {
        HideObject();
        timerIsRunning = true;
        yield return new WaitForSeconds(duration);
        PowerUpNormal();
        Destroy(gameObject);
    }

    void HideObject()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    void TimerPowerUp()
    {
        if (timerIsRunning)
        {
            if (PowerUpDuration > 1)
            {
                PowerUpDuration -= Time.fixedDeltaTime;
                Debug.Log(Mathf.FloorToInt(PowerUpDuration % 60));
            }
            else
            {
                PowerUpDuration = 0;
            }
        }
    }
}

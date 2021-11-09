using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    [SerializeField] float duration = 2;
    [SerializeField] float sizeAfterPickingUp = 0.832f;
    Transform targetPositionInUI;
    [SerializeField] float speedTargetPosition = 1.5f;
    public static float PowerUpDuration { get; private set; }
    bool movePowerUp = false;
    bool timerIsRunning = false, initTimerIsRunning = false;
    ShotsTypesController shotsTypes;
    Color colorPowerUp;

    void Start()
    {
        colorPowerUp = GetComponent<SpriteRenderer>().color;
        GameObject backgroundPowerUp = GameObject.FindWithTag("BackgroundPowerUp");
        if (backgroundPowerUp != null)
        {
            targetPositionInUI = backgroundPowerUp.transform;
        }
    }

    void FixedUpdate()
    {
        InitTimerPowerUp();
        TimerPowerUp();
        MovePowerUp();
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
        GetComponent<CircleCollider2D>().enabled = false;
        transform.localScale = new Vector3(sizeAfterPickingUp, sizeAfterPickingUp, transform.localScale.z);

        GameObject[] powerUpTripleInScene = GameObject.FindGameObjectsWithTag("PowerUpShotTriple");
        GameObject[] powerUpDoubleInScene = GameObject.FindGameObjectsWithTag("PowerUpShotDouble");
        GameObject[] powerUpsInScene = powerUpTripleInScene.Concat(powerUpDoubleInScene).ToArray();

        foreach (var item in powerUpsInScene)
        {
            SpriteRenderer render = item.gameObject.GetComponent<SpriteRenderer>();
            CircleCollider2D collider = item.gameObject.GetComponent<CircleCollider2D>();
            if (render != null && collider.enabled == false)
            {
                render.sortingLayerID = SortingLayer.NameToID("UI");
                render.sortingOrder = 1;
            }
        }

        GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("UI");
        GetComponent<SpriteRenderer>().sortingOrder = 10;

        movePowerUp = true;
    }

    void MovePowerUp()
    {
        if (movePowerUp && targetPositionInUI != null)
        {
            float step = speedTargetPosition * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPositionInUI.position, step);
        }
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

            if (colorPowerUp != null)
            {
                Debug.Log("addddddd");
                colorPowerUp.a = PowerUpDuration;
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

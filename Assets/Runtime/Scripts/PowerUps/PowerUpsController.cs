using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    [SerializeField] AudioClip soundWhenPickingUp;
    [SerializeField] float duration = 2;
    [SerializeField] float sizeAfterPickingUp = 0.832f;
    Transform targetPositionInUI;
    [SerializeField] float speedTargetPosition = 1.5f;
    public static float PowerUpDuration { get; private set; }
    bool movePowerUp = false;
    bool timerIsRunning = false, initTimerIsRunning = false;
    ShotsTypesController shotsTypes;
    SpriteRenderer colorPowerUp;

    void Start()
    {
        colorPowerUp = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        InitTimerPowerUp();
        TimerPowerUp();
        MovePowerUp();
    }

    void SetTargetPositionInUI()
    {
        GameObject backgroundPowerUp = GameObject.FindWithTag("BackgroundPowerUp");
        if (backgroundPowerUp != null)
        {
            targetPositionInUI = backgroundPowerUp.transform;
        }
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
                AudioController.Instance.PlayAudioCue(soundWhenPickingUp);

                SetTargetPositionInUI();

                initTimerIsRunning = true;

                if (gameObject.tag == "PowerUpShotTriple")
                {
                    PowerUpTriple();
                }

                if (gameObject.tag == "PowerUpShotDouble")
                {
                    PowerUpDouble();
                }
            }
        }
    }

    void PowerUpNormal()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Normal;
    }

    void PowerUpDouble()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Double;
        MovePowerUpToUI();
    }

    void PowerUpTriple()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Triple;
        MovePowerUpToUI();
    }

    void MovePowerUpToUI()
    {
        timerIsRunning = true;

        TransformCollectedPowerIntoUI();

        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("UI");
        GetComponent<SpriteRenderer>().sortingOrder = 10;

        movePowerUp = true;

        AdjustScalePowerUp();
    }

    void AdjustScalePowerUp()
    {
        transform.localScale = new Vector3(sizeAfterPickingUp, sizeAfterPickingUp, transform.localScale.z);
    }

    void TransformCollectedPowerIntoUI()
    {
        foreach (var item in GetPowerUpsByTag())
        {
            SpriteRenderer render = item.GetComponent<SpriteRenderer>();
            CircleCollider2D collider = item.GetComponent<CircleCollider2D>();
            if (render != null && collider.enabled == false)
            {
                render.sortingLayerID = SortingLayer.NameToID("UI");
                render.sortingOrder = 1;
            }
        }
    }

    GameObject[] GetPowerUpsByTag()
    {
        GameObject[] powerUpTripleInScene = GameObject.FindGameObjectsWithTag("PowerUpShotTriple");
        GameObject[] powerUpDoubleInScene = GameObject.FindGameObjectsWithTag("PowerUpShotDouble");
        GameObject[] powerUpsInScene = powerUpTripleInScene.Concat(powerUpDoubleInScene).ToArray();
        return powerUpsInScene;
    }

    void MovePowerUp()
    {
        if (movePowerUp && targetPositionInUI != null)
        {
            float step = speedTargetPosition * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPositionInUI.position, step);
        }
    }

    void SetTransparence(float value)
    {
        if (colorPowerUp != null)
        {
            colorPowerUp.material.color = new Color(1, 1, 1, PowerUpDuration);
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
            SetTransparence(PowerUpDuration);
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

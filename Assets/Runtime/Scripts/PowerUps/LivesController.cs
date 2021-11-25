using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    [SerializeField] AudioClip soundWhenPickingUp;
    [SerializeField] float speedTargetPosition = 4f;
    Transform targetPositionInUI;
    bool moveLife = false;
    SpriteRenderer colorPowerUp;

    void Start()
    {
        colorPowerUp = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        MoveLife();
    }

    void SetTargetPositionInUI()
    {
        GameObject backgroundPowerUp = GameObject.FindWithTag("BackgroundLiveBar");
        if (backgroundPowerUp != null)
        {
            targetPositionInUI = backgroundPowerUp.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AudioController.Instance.PlayAudioCue(soundWhenPickingUp);

            SetTargetPositionInUI();
            moveLife = true;
        }
    }

    void MoveLife()
    {
        if (moveLife && targetPositionInUI != null)
        {
            float step = speedTargetPosition * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPositionInUI.position, step);
        }

        if (targetPositionInUI != null && (transform.position == targetPositionInUI.position))
        {
            Destroy(gameObject);
        }
    }
}

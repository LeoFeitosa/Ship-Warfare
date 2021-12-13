using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveItemsController))]
public class LivesController : MonoBehaviour
{
    [SerializeField] AudioClip soundWhenPickingUp;
    [SerializeField] float speedTargetPosition = 1.5f;
    Transform targetPositionInUI;
    bool moveLife = false;

    void Update()
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
            float step = speedTargetPosition * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPositionInUI.position, step);
        }

        if (targetPositionInUI != null && (transform.position == targetPositionInUI.position))
        {
            Destroy(gameObject);
        }
    }
}

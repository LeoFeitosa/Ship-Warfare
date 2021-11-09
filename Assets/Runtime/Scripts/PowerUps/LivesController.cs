using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesController : MonoBehaviour
{
    [SerializeField] float speedTargetPosition = 4f;
    Transform targetPositionInUI;
    bool moveLife = false;
    SpriteRenderer colorPowerUp;

    void Start()
    {
        colorPowerUp = GetComponent<SpriteRenderer>();

        GameObject backgroundPowerUp = GameObject.FindWithTag("BackgroundLife");
        if (backgroundPowerUp != null)
        {
            targetPositionInUI = backgroundPowerUp.transform;
        }
    }

    void FixedUpdate()
    {
        MoveLife();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
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
        if (transform.position == targetPositionInUI.position)
        {
            Destroy(gameObject);
        }
    }
}

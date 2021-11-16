using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCurveController : MonoBehaviour
{
    [SerializeField] float angle = 40f;
    [SerializeField] float speed = 0.03f;
    [SerializeField] float heightToStartOfCurve = 3;
    float timeToFinalAngle = 0;

    void FixedUpdate()
    {
        MoveCurve();
    }

    void MoveCurve()
    {
        if (transform.position.y < heightToStartOfCurve)
        {
            timeToFinalAngle += speed * Time.fixedDeltaTime;
        }
        if (timeToFinalAngle >= angle)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(0, 0, timeToFinalAngle);
    }
}

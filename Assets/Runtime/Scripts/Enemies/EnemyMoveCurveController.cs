using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCurveController : MonoBehaviour
{
    [SerializeField] float angle = 40f;
    [SerializeField] float speed = 0.03f;
    [SerializeField] float heightToStartOfCurve = 3;
    float timeToFinalAngle = 0;
    int leftRight = 0;
    GameObject mainHUDObject;
    MainHUD mainHUD;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        leftRight = (transform.position.x < 0) ? -1 : 1;
    }

    void FixedUpdate()
    {
        MoveCurve();
    }

    void MoveCurve()
    {
        if (!mainHUD.IsCountSeconds)
        {
            if (heightToStartOfCurve > transform.position.y)
            {
                timeToFinalAngle += speed * Time.fixedDeltaTime;
            }
            if (timeToFinalAngle >= angle)
            {
                return;
            }

            transform.rotation = Quaternion.Euler(0, 0, timeToFinalAngle * leftRight);
        }
    }
}

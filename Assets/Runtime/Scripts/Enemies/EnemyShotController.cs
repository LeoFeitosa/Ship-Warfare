using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveUpDownController))]
[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(EnemyController))]
public class EnemyShotController : MonoBehaviour
{
    [SerializeField] Transform[] positionStartShot;
    [SerializeField] GameObject enemyShotUpPrefab;
    [SerializeField] GameObject enemyShotDownPrefab;
    [SerializeField] float delayShot = 1;
    bool canShoot = true;
    EnemyMoveUpDownController enemyMoveUpDown;
    bool invert;
    bool enableShot = false;
    EnemyController enemyController;
    EnemyAnimationController enemyAnimation;
    Transform rotationShip;

    void Start()
    {
        enemyMoveUpDown = GetComponent<EnemyMoveUpDownController>();
        enemyController = GetComponent<EnemyController>();
        enemyAnimation = GetComponent<EnemyAnimationController>();
        rotationShip = GetComponent<Transform>();
        invert = enemyMoveUpDown.IsInvert;
    }

    void FixedUpdate()
    {
        InstanceShot();
    }

    void InstanceShot()
    {
        if (canShoot && enableShot && rotationShip != null && !enemyAnimation.IsDead)
        {
            canShoot = false;

            GameObject prefabShot;

            if (invert)
            {
                prefabShot = enemyShotUpPrefab;
            }
            else
            {
                prefabShot = enemyShotDownPrefab;
            }

            foreach (var item in positionStartShot)
            {
                Quaternion rotation = item.rotation * rotationShip.localRotation;
                prefabShot.tag = "Enemy";
                Instantiate(prefabShot, item.position, rotation);
            }

            StartCoroutine(TimeForShooting());
        }
    }

    IEnumerator TimeForShooting()
    {
        yield return new WaitForSeconds(delayShot);
        canShoot = true;
    }

    void OnBecameVisible()
    {
        enableShot = true;
    }
}

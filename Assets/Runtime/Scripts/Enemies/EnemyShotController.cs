using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        enemyMoveUpDown = GetComponent<EnemyMoveUpDownController>();
        invert = enemyMoveUpDown.IsInvert;
    }

    void Update()
    {
        InstanceShot();
    }

    void InstanceShot()
    {
        if (canShoot && enableShot)
        {
            canShoot = false;

            Transform rotationShip = GetComponent<Transform>();
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

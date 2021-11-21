using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveUpDownController))]
public class EnemyShotController : MonoBehaviour
{
    [SerializeField] Transform[] positionStartShot;
    [SerializeField] GameObject enemyShotUpPrefab;
    [SerializeField] GameObject enemyShotDownPrefab;
    [SerializeField] float delayShot = 1;
    [SerializeField] float speedColorSwap = 0.03f;
    bool canShoot = true;
    EnemyMoveUpDownController enemyMoveUpDown;
    bool invert;

    void Start()
    {
        enemyMoveUpDown = GetComponent<EnemyMoveUpDownController>();
        invert = enemyMoveUpDown.IsInvert;
    }

    void Update()
    {
        if (canShoot)
        {
            canShoot = false;

            Transform rotationShip = GetComponent<Transform>();
            GameObject prefabShot;

            if (invert)
            {
                prefabShot = enemyShotDownPrefab;
            }
            else
            {
                prefabShot = enemyShotUpPrefab;
            }


            foreach (var item in positionStartShot)
            {
                Quaternion rotation = item.rotation * rotationShip.localRotation;
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
}

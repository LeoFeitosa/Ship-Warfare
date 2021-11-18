using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveUpDownController))]
public class EnemyShotController : MonoBehaviour
{
    [SerializeField] Transform positionStartShot;
    [SerializeField] GameObject enemyShotUpPrefab;
    [SerializeField] GameObject enemyShotDownPrefab;
    [SerializeField] float delayShot = 1;
    bool canShoot = true;
    EnemyMoveUpDownController enemyMoveUpDown;
    bool invert;

    void Start()
    {
        enemyMoveUpDown = GetComponent<EnemyMoveUpDownController>();
        invert = enemyMoveUpDown.IsInvert;
    }

    // Update is called once per frame
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

            Instantiate(prefabShot, positionStartShot.position, rotationShip.localRotation);

            StartCoroutine(TimeForShooting());
        }
    }

    IEnumerator TimeForShooting()
    {
        yield return new WaitForSeconds(delayShot);
        canShoot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMoveUpDownController))]
public class EnemyShotController : MonoBehaviour
{
    [SerializeField] Transform positionStartShot;
    [SerializeField] GameObject enemyShotPrefab;
    [SerializeField] float delayShot = 1;
    bool canShoot = true;
    EnemyMoveUpDownController enemyMoveUpDown;

    void Start()
    {
        enemyMoveUpDown = GetComponent<EnemyMoveUpDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            Quaternion angle = Quaternion.identity;
            if (enemyMoveUpDown.IsInvert)
            {
                angle = Quaternion.Euler(0, 0, 360);
            }
            else
            {
                angle = Quaternion.Euler(0, 0, 0);
            }
            Instantiate(enemyShotPrefab, positionStartShot.position, angle);

            StartCoroutine(TimeForShooting());
        }
    }

    IEnumerator TimeForShooting()
    {
        yield return new WaitForSeconds(delayShot);
        canShoot = true;
    }
}

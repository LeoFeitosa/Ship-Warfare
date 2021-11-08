using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    [SerializeField] float powerUpDuration = 2;
    ShotsTypesController shotsTypes;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            shotsTypes = col.gameObject.GetComponentInParent<ShotsTypesController>();

            if (shotsTypes != null)
            {
                if (gameObject.tag == "PowerUpShotTriple")
                {
                    PowerUpTriple();
                }

                if (gameObject.tag == "PowerUpShotDouble")
                {
                    PowerUpDouble();
                }

                if (gameObject.tag == "PowerUpOneMoreLife")
                {
                    PowerUpOneMoreLife();
                }

            }
            else
            {
                Debug.LogError("Não foi possivel encontrar o gameObject ShotsTypesController");
            }
        }
    }

    void PowerUpOneMoreLife()
    {
        Debug.Log("Mais uma vida");
    }

    void PowerUpNormal()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Normal;
    }

    void PowerUpDouble()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Double;
        StartCoroutine(TimeToInterruptPowerUp());
    }

    void PowerUpTriple()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Triple;
        StartCoroutine(TimeToInterruptPowerUp());
    }

    IEnumerator TimeToInterruptPowerUp()
    {
        yield return new WaitForSeconds(powerUpDuration);
        PowerUpNormal();
    }
}

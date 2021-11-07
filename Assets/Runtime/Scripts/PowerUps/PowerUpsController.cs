using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    ShotsTypesController shotsTypes;
    public void PowerUpNormal()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Normal;
    }

    public void PowerUpDouble()
    {
        shotsTypes.shotType = ShotsTypesController.ShotType.Double;
    }

    public void PowerUpTriple()
    {
        Debug.Log("ok");
        shotsTypes.shotType = ShotsTypesController.ShotType.Triple;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            shotsTypes = col.gameObject.GetComponent<ShotsTypesController>();

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
            }
            else
            {
                Debug.Log("nao achou o componente");
            }
        }
    }
}

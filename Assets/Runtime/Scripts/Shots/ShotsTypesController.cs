using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsTypesController : MonoBehaviour
{
    [SerializeField] AudioClip shot;
    [SerializeField] Transform shotStartPosition;
    [SerializeField] GameObject shotNormalPrefab;
    [SerializeField] float angleShot = 10;
    public enum ShotType
    {
        Normal, Double, Triple
    };
    public ShotType shotType;
    bool canShoot = true;
    [SerializeField] float delayShot = 2;

    public void ShootShot(bool shoot)
    {
        if (shoot && canShoot)
        {
            canShoot = false;

            switch (shotType)
            {
                case ShotType.Normal:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    break;
                case ShotType.Double:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, angleShot));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, -angleShot));
                    break;
                case ShotType.Triple:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, angleShot));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, -angleShot));
                    break;
                default:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    break;
            }

            StartCoroutine(TimeForShooting());
        }
    }

    IEnumerator TimeForShooting()
    {
        AudioController.Instance.PlayAudioCue(shot);
        yield return new WaitForSeconds(delayShot);
        canShoot = true;
    }
}

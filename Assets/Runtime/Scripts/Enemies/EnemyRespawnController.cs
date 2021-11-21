using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnController : MonoBehaviour
{
    [Header("Random Spawn Interval")]
    [SerializeField] int intervalInitial = 2;
    [SerializeField] int intervalFinal = 3;

    [Header("Small")]
    [SerializeField] GameObject[] SmallEnemiesPrefab;

    [Header("Medium")]
    [SerializeField] GameObject[] MediumEnemiesPrefab;

    [Header("Big")]
    [SerializeField] GameObject[] BigEnemiesPrefab;

    int countInterval;

    void Start()
    {
        countInterval = Random.Range(intervalInitial, intervalFinal);
        StartCoroutine(IntervalBetweenRespawn());
    }

    IEnumerator IntervalBetweenRespawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(countInterval);
            countInterval = Random.Range(intervalInitial, intervalFinal);
            GetRandomEnemie(GetRandomArrayPrefab());
        }
    }

    GameObject[] GetRandomArrayPrefab()
    {
        int arrayIdentification = Random.Range(0, 3);
        GameObject[] selectedArray;
        switch (arrayIdentification)
        {
            case 0:
                selectedArray = SmallEnemiesPrefab;
                break;
            case 1:
                selectedArray = MediumEnemiesPrefab;
                break;
            case 2:
                selectedArray = BigEnemiesPrefab;
                break;
            default:
                selectedArray = SmallEnemiesPrefab;
                break;
        }
        return selectedArray;
    }

    void GetRandomEnemie(GameObject[] enemies)
    {
        int index = Random.Range(0, enemies.Length);
        Instantiate(enemies[index]);
    }
}

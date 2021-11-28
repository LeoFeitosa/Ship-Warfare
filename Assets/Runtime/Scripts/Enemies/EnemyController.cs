using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Respawn PowerUps")]
    [Range(0.01f, 1f)]
    [SerializeField] float probabilityOfAppearing = 1;
    [SerializeField] GameObject[] PowerUpsPrefab;

    [Header("Data Enemies")]
    [SerializeField] AudioClip soundEnemyDie;
    EnemyAnimationController enemyAnimation;
    PlayerController player;
    BoxCollider2D colliderEnemy;
    UIScoreController uIScoreController;
    [SerializeField] int pointsToBeDestroyed;

    void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimationController>();
        colliderEnemy = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerController>();
        uIScoreController = FindObjectOfType<UIScoreController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerShot"))
        {
            Die();
            AudioController.Instance.PlayAudioCue(soundEnemyDie);
            RespawnPowerUp();
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Player") && (player != null && player.PlayerColliderWithEnemy))
        {
            Die();
        }
    }

    void RespawnPowerUp()
    {
        if (Random.value < probabilityOfAppearing)
        {

            Instantiate(PowerUpsPrefab[Random.Range(0, PowerUpsPrefab.Length)], transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        uIScoreController.SetScore(pointsToBeDestroyed);
        colliderEnemy.enabled = false;
        enemyAnimation.IsDead = true;
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

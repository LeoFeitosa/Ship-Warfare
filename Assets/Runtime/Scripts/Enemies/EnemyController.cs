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
            GameObject powerUp = PowerUpsPrefab[Random.Range(0, PowerUpsPrefab.Length)];

            if (powerUp.name == "LiveExtra" && player.Lives < player.MaxLives && FindObjectOfType<LivesController>() == null)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }

            if (powerUp.name != "LiveExtra" && FindObjectOfType<PowerUpsController>() == null)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }
        }
    }

    void Die()
    {
        colliderEnemy.enabled = false;
        enemyAnimation.IsDead = true;
        uIScoreController = FindObjectOfType<UIScoreController>();
        uIScoreController.SetScore(pointsToBeDestroyed);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

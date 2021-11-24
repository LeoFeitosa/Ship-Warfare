using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Player") && (player != null && player.PlayerColliderWithEnemy))
        {
            Die();
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

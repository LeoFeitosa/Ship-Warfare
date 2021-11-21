using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyAnimationController enemyAnimation;
    PlayerController player;

    void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimationController>();
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && (player != null && player.PlayerColliderWithEnemy))
        {
            Die();
        }
    }

    void Die()
    {
        enemyAnimation.IsDead = true;
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

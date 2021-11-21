using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerController playerController;
    private static readonly int moveId = Animator.StringToHash("Move");
    private static readonly int explosion = Animator.StringToHash("Explosion");

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        animator.SetFloat(moveId, playerController.IsMove);
        if (playerController.IsDead)
        {
            animator.SetTrigger(explosion);
        }
    }
}

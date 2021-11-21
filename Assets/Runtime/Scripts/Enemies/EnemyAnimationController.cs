using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool IsDead { get; set; }
    private static readonly int explosion = Animator.StringToHash("EnemyDie");

    void Start()
    {
        IsDead = false;
    }

    void LateUpdate()
    {
        if (IsDead)
        {
            IsDead = false;

            if (animator != null)
            {
                animator.SetTrigger(explosion);
            }
        }
    }
}

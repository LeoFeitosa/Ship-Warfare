using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDownController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    float timeToRespawn = 0;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + startPosition, transform.position.z);
    }

    void FixedUpdate()
    {
        MoveDown();
    }

    void MoveDown()
    {
        timeToRespawn += Time.fixedDeltaTime;

        if (timeToRespawn >= startPosition)
        {
            transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
        }
    }
}

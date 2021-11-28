using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItemsController : MonoBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField] float limitMoveX;
    [SerializeField] float limitMoveY;
    Vector3 moveDirections = Vector3.zero;
    bool stopMove = true;


    void Start()
    {
        moveDirections = RandomBool() ? DirectionPositive() : DirectionNegative();
        stopMove = false;
    }

    void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        if (stopMove)
        {
            return;
        }

        if (transform.position.x < -limitMoveX || transform.position.y < -limitMoveY)
        {
            moveDirections = DirectionPositive();
        }

        if (transform.position.x > limitMoveX || transform.position.y > limitMoveY)
        {
            moveDirections = DirectionNegative();
        }

        transform.position += moveDirections.normalized * speedMove * Time.deltaTime;
    }

    Vector3 DirectionPositive()
    {
        return new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), transform.position.z);
    }

    Vector3 DirectionNegative()
    {
        return new Vector3(Random.Range(-1f, 0f), Random.Range(-1f, 0f), transform.position.z);
    }

    bool RandomBool()
    {
        if (Random.Range(0, 1) == 1)
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            stopMove = true;
        }
    }
}

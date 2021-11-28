using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveItemsController : MonoBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField] float speedRoration;
    [SerializeField] float limitMoveX;
    [SerializeField] float limitMoveY;
    Vector3 moveDirections = Vector3.zero;
    bool stopMove = true;
    bool stopRotate = true;

    void Start()
    {
        moveDirections = RandomBool() ? DirectionPositive() : DirectionNegative();
        speedRoration = RandomBool() ? speedRoration : -speedRoration;
        stopMove = false;
        stopRotate = false;
    }

    void LateUpdate()
    {
        Move();
        RotatePowerUp();
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

    void RotatePowerUp()
    {
        if (stopRotate)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Lerp(transform.rotation.z, 0, speedRoration * Time.deltaTime));
        }
        else
        {
            transform.Rotate(0, 0, speedRoration * Time.deltaTime, Space.Self);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            stopMove = true;
            stopRotate = true;
        }
    }
}

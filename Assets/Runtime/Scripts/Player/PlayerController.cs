using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInputController input;
    Vector3 moveDirections = Vector3.zero;
    Rigidbody2D rb2D;
    [SerializeField] float speedMoveNormal = 0.5f;

    void Start()
    {
        input = GetComponent<PlayerInputController>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move(input.Movements());
    }

    void Move(Vector3 move)
    {
        moveDirections += move * speedMoveNormal * Time.fixedDeltaTime;
        rb2D.MovePosition(moveDirections);
    }
}

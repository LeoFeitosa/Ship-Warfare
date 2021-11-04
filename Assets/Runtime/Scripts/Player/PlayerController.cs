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
    [SerializeField] float limitMoveX = 4f;
    [SerializeField] float limitMoveY = 4f;

    public float IsMove { get; private set; }

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
        IsMove = move.x;

        moveDirections += move * speedMoveNormal * Time.fixedDeltaTime;

        moveDirections.x = Mathf.Clamp(moveDirections.x, limitMoveX * -1, limitMoveX);
        moveDirections.y = Mathf.Clamp(moveDirections.y, limitMoveY * -1, limitMoveY);

        rb2D.MovePosition(moveDirections);
    }
}

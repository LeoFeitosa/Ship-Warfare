using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    PlayerInputController input;
    Vector3 moveDirections = Vector3.zero;
    Rigidbody2D rb2D;
    [SerializeField] float speedMoveNormal = 0.5f;
    [SerializeField] float limitMoveX = 4f;
    [SerializeField] float limitMoveY = 4f;

    [Header("Shoots")]
    [SerializeField] Transform shotStartPosition;
    [SerializeField] GameObject shotNormalPrefab;
    [SerializeField] float angleShot = 10;
    public enum ShotType
    {
        Normal, Double, Triple
    };
    public ShotType shotType;

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

    void Update()
    {
        ShootShot(input.Shoot());
    }

    void Move(Vector3 move)
    {
        IsMove = move.x;

        moveDirections += move * speedMoveNormal * Time.fixedDeltaTime;

        moveDirections.x = Mathf.Clamp(moveDirections.x, limitMoveX * -1, limitMoveX);
        moveDirections.y = Mathf.Clamp(moveDirections.y, limitMoveY * -1, limitMoveY);

        rb2D.MovePosition(moveDirections);
    }

    void ShootShot(bool shoot)
    {
        if (shoot)
        {
            switch (shotType)
            {
                case ShotType.Normal:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    break;
                case ShotType.Double:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, angleShot));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, -angleShot));
                    break;
                case ShotType.Triple:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, angleShot));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, -angleShot));
                    break;
                default:
                    Instantiate(shotNormalPrefab, shotStartPosition.position, Quaternion.Euler(0, 0, 0));
                    break;
            }
        }
    }
}
